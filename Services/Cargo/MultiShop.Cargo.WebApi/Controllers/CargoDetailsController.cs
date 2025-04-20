using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;

        public CargoDetailsController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _CargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail
            {
             Barcode=createCargoDetailDto.Barcode,
             CargoCompanyId=createCargoDetailDto.CargoCompanyId,
             ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
             SenderCustomer= createCargoDetailDto.SenderCustomer
            };
            _CargoDetailService.TInsert(CargoDetail);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Silme işlemi Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                CargoDetailId=updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer
            };
            _CargoDetailService.TUpdate(CargoDetail);
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
