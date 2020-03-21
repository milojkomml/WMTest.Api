using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WMTest.Api.BusinessLogic.Interface;
using WMTest.Api.Models;

namespace WMTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WMTestController : Controller
    {
        private IWMTestBusinessLogic wMTestBusinessLogic;
        public WMTestController(IWMTestBusinessLogic _wMTestBusinessLogic)
        {
            wMTestBusinessLogic = _wMTestBusinessLogic;
        }
        [HttpGet]
        [Route("[controller]/GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var response = wMTestBusinessLogic.GetAllProducts(); 
            return Ok(response);
        }
        [HttpGet]
        [Route("[controller]/GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var response = wMTestBusinessLogic.GetProduct(id);
            return Ok(response);
        }
        [HttpPost]
        [Route("[controller]/InsertProduct")]
        public IActionResult InsertProduct(string naziv, string opis, string kategorija, string proizvodjac, string dobavljac, float cena)
        {
            var response = wMTestBusinessLogic.InsertProduct(naziv, opis, kategorija, proizvodjac, dobavljac, cena);
            return Ok(response);
        }
        [HttpPost]
        [Route("[controller]/UpdateProduct")]
        public IActionResult UpdateProduct(int id, string naziv, string opis, string kategorija, string proizvodjac, string dobavljac, float cena)
        {
            var response = wMTestBusinessLogic.UpdateProduct(id, naziv, opis, kategorija, proizvodjac, dobavljac, cena);
            return Ok(response);
        }
        [HttpDelete]
        [Route("[controller]/DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            var response = wMTestBusinessLogic.DeleteProduct(id);
            return Ok();
        }
    }
}
