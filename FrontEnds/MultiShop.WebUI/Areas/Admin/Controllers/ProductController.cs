using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Security.Cryptography.Xml;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Ürün İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(JsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            var JsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(JsonData);
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
           
        }
		[Route("CreateProduct")]
		[HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProduct)
        {
			var client= _httpClientFactory.CreateClient();
			var JsonData = JsonConvert.SerializeObject(createProduct);
			StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7070/api/Products", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}
			return View();
		}
		[Route("DeleteProduct/{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Products/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });

			}
			return View();
		}
		[HttpGet]
		[Route("UpdateProduct/{id}")]
		public async Task<IActionResult> UpdateProduct(string id)
		{
			ViewBag.v0 = "Ürün İşlemleri";
			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Ürünler";
			ViewBag.v3 = "Ürünleri Güncelleme İşlemleri";

			var client1 = _httpClientFactory.CreateClient();
			var responseMessage1 = await client1.GetAsync("https://localhost:7070/api/Categories");
			var JsonData1 = await responseMessage1.Content.ReadAsStringAsync();
			var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(JsonData1);
			List<SelectListItem> categoryValues1 = (from x in values1
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID
												   }).ToList();
			ViewBag.CategoryValues = categoryValues1;


			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var JsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(JsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateProduct/{id}")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var JsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7070/api/Products", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}
			return View();

		}

	}
}
