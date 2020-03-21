using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMTest.Api.Models;

namespace WMTest.Api.BusinessLogic.Interface
{
    public interface IWMTestBusinessLogic
    {
        public List<Product> GetAllProducts();
        public Product GetProduct(int id);
        public Product InsertProduct(string naziv, string opis, string kategorija, string proizvodjac, string dobavljac, float cena);
        public Product UpdateProduct(int id, string naziv, string opis, string kategorija, string proizvodjac, string dobavljac, float cena);
        public Product DeleteProduct(int id);
    }
}
