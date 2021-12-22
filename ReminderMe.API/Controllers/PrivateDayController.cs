using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReminderMe.API.Helper;
using ReminderMe.DomainCore.DBModel.Concrete;
using ReminderMe.ServiceCore.CommonRepository.Abstract;
using SecuringWebApiUsingApiKey.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReminderMe.API.Controllers
{
    //[ApiKey]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrivateDayController : ControllerBase
    {
        private readonly ILogger<PrivateDayController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork unitOfWork;

        public PrivateDayController(ILogger<PrivateDayController> logger, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _configuration = configuration;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<string> Index()
        {
            _logger.LogInformation($"{DateTime.Now} --> Servis Başladı");
            return new string[] { "Plate-Recognition", "Api" };
        }

        //[HttpPost]
        //[Route("~/api/AddPlate")]
        //public async Task<JsonResult> AddPlate(Ozel_Gunler pd)
        //{
        //    try
        //    {
        //        pd.IsActive = true;
        //        var processResult = await unitOfWork.PrivateDays.AddAsync(pd);

        //        if (processResult != 0)
        //        {
        //            _logger.LogInformation($"{DateTime.Now} --> Plaka Ekleme İşlemi Başarılı! İşlem Yapılan Araç Plaka: {plate.PlateText}");
        //            return new JsonResult(new { success = true, message = "Plaka Ekleme İşlemi Başarılı!" });
        //        }
        //        else
        //        {
        //            _logger.LogError($"{DateTime.Now} --> Plaka Ekleme İşlemi Başarısız! İşlem Yapılan Araç Plaka: {plate.PlateText}");
        //            return new JsonResult(new { success = false, message = "Plaka Ekleme İşlemi Başarısız! Lütfen Daha Sonra Tekrar Deneyiniz...", data = "" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError($"{DateTime.Now} --- Sistemsel Hata Mesajı: {ex.Message}");
        //        return new JsonResult(new { success = false, message = ex.Message });
        //    }
        //}


        [HttpGet]
        [Route("~/api/GetPrivateDayList")]
        public async Task<JsonResult> GetPrivateDayList()
        {
            try
            {
                var processResult = await unitOfWork.PrivateDays.GetAllAsync();

                if (processResult != null && processResult.Count > 0)
                {
                    MailHelper.SendMail(processResult);
                    return new JsonResult(new { success = true, message = "İşlem Başarılı!", dataCount = processResult.Count,  data = processResult });
                }
                else
                {
                    return new JsonResult(new { success = false, message = "İşlem Başarısız! Lütfen Daha Sonra Tekrar Deneyiniz...", data = "" });
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"{DateTime.Now} --- Sistemsel Hata Mesajı: {ex.Message}");
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        //[HttpGet]
        //[Route("~/api/GetPlateInfoById")]
        //public async Task<JsonResult> GetPlateInfoById(string id)
        //{
        //    try
        //    {
        //        var idConvert = Guid.Parse(id);
        //        var processResult = await unitOfWork.Plates.GetByIdAsync(idConvert);

        //        if (processResult != null)
        //        {
        //            return new JsonResult(new { success = true, message = "İşlem Başarılı!", data = processResult });
        //        }
        //        else
        //        {
        //            return new JsonResult(new { success = false, message = "İşlem Başarısız! Lütfen Daha Sonra Tekrar Deneyiniz...", data = "" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError($"{DateTime.Now} --- Sistemsel Hata Mesajı: {ex.Message}");
        //        return new JsonResult(new { success = false, message = ex.Message });
        //    }
        //}

        //[HttpPost]
        //[Route("~/api/EditPlate")]
        //public async Task<JsonResult> EditPlate(Plate plate)
        //{
        //    try
        //    {
        //        //var idConvert = Guid.Parse(plate)
        //        var processResult = await unitOfWork.Plates.UpdateAsync(plate);

        //        if (processResult != 0)
        //        {
        //            return new JsonResult(new { success = true, message = "İşlem Başarılı!", data = processResult });
        //        }
        //        else
        //        {
        //            return new JsonResult(new { success = false, message = "İşlem Başarısız! Lütfen Daha Sonra Tekrar Deneyiniz...", data = "" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        _logger.LogError($"{DateTime.Now} --- Sistemsel Hata Mesajı: {ex.Message}");
        //        return new JsonResult(new { success = false, message = ex.Message });
        //    }
        //}
    }
}
