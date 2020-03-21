using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMTest.Api.BusinessLogic.Interface;
using WMTest.Api.Models;
using WMTest.Api.Services.Interface;

namespace WMTest.Api.BusinessLogic
{
    public class WMTestBusinessLogic : IWMTestBusinessLogic
    {
        private IWMTestService wMTestService;
        public WMTestBusinessLogic(IWMTestService _wMTestService)
        {
            wMTestService = _wMTestService;
        }
        public List<Product> GetAllProducts()
        {
            var response = wMTestService.GetAllProducts();
            return response;
        }
        public Product GetProduct(int id)
        {
            var response = wMTestService.GetProduct(id);
            return response;
        }
        public Product InsertProduct(string naziv, string opis, string kategorija, string proizvodjac, string dobavljac, float cena)
        {
            var response = wMTestService.InsertProduct(naziv, opis, kategorija, proizvodjac, dobavljac, cena);
            return response;
        }
        public Product UpdateProduct(int id, string naziv, string opis, string kategorija, string proizvodjac, string dobavljac, float cena)
        {
            var response = wMTestService.UpdateProduct(id, naziv, opis, kategorija, proizvodjac, dobavljac, cena);
            return response;
        }
        public Product DeleteProduct(int id)
        {
            var response = wMTestService.DeleteProduct(id);
            return response;
        }
    }
}
