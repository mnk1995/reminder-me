using ReminderMe.DomainCore.DBModel;
using ReminderMe.DomainCore.DBModel.Abstract;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Reflection;
using ReminderMe.DomainCore.DBModel.Concrete;

namespace ReminderMe.ServiceCore.CommonRepository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        IConfiguration configuration;
        public GenericRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                    .GetProperties()
                    //.Where(e => !e.PropertyType.GetTypeInfo().IsGenericType)
                    .Select(e => e.Name);
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            int result;
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"insert into {typeof(T).Name}s ({stringOfColumns}) values ({stringOfParameters})";
            //entity.create_date = DateTime.Now;
            //var sql = "Insert into tbl_users (name,email,phone,password,last_login_date,wallet,status,companyname,scores) VALUES (@name,@email,@phone,@password,@last_login_date,@wallet,@status,@companyname,@scores)";

            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                try
                {
                    result = await connection.ExecuteAsync(query, entity);
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {
                    result = 0;
                }
                connection.Close();
                return result;
            };

        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            int result;
            var sql = $"DELETE FROM {typeof(T).Name}s WHERE Id = @Id";
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                try
                {
                    result = await connection.ExecuteAsync(sql, new { Id = id });
                    transactionScope.Complete();

                }
                catch (Exception ex)
                {
                    result = 0;
                }
                connection.Close();
                return result;
            }
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {typeof(T).Name}s";
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                try
                {
                    var result = await connection.QueryAsync<T>(sql);
                    connection.Close();
                    transactionScope.Complete();
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return null;
                }

            }
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                var sql = $"SELECT * FROM {typeof(T).Name}s WHERE Id = @Id";
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    try
                    {
                        var result = await connection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
                        connection.Close();
                        transactionScope.Complete();
                        return result;
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return null;
                    }

                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            int result;
            //entity.modify_date = DateTime.Now;
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"update {typeof(T).Name}s set {stringOfColumns} where Id = @Id";
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                try
                {
                    result = await connection.ExecuteAsync(query, entity);
                    transactionScope.Complete();
                }
                catch (Exception ex)
                {

                    result = 0;
                }
                connection.Close();
                return result;
            }
        }
    }
}
