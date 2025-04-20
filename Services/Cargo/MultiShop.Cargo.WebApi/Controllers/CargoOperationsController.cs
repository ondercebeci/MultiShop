using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;

        public CargoOperationsController(ICargoOperationService CargoOperationService)
        {
            _CargoOperationService = CargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _CargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _CargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            };
            _CargoOperationService.TInsert(cargoOperation);
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok("Silme işlemi Başarılı");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation()
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };
            _CargoOperationService.TUpdate(CargoOperation);
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
