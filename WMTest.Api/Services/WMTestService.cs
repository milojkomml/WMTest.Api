using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMTest.Api.Services.Interface;
using WMTest.Api.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace WMTest.Api.Services
{
    public class WMTestService : IWMTestService
    {
        private readonly IConfiguration configuration;
        public WMTestService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string connectionString = configuration.GetConnectionString("WMTestDatabase");

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetAllProizvod";

            var sqlRead = command.ExecuteReader();
            while (sqlRead.Read())
            {
                Product product = new Product();
                product.Id = Int32.Parse(sqlRead["Id"].ToString());
                product.Naziv = sqlRead["Naziv"].ToString();
                product.Opis = sqlRead["Opis"].ToString();
                product.Kategorija = sqlRead["Kategorija"].ToString();
                product.Proizvođač = sqlRead["Proizvođač"].ToString();
                product.Dobavljač = sqlRead["Dobavljač"].ToString();
                product.Cena = float.Parse(sqlRead["Cena"].ToString());

                products.Add(product);
            }

            sqlConnection.Close();

            return products;
        }
        public Product GetProduct(int id)
        {
            Product product = new Product();
            string connectionString = configuration.GetConnectionString("WMTestDatabase");

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "GetProduct";
            command.Parameters.AddWithValue("@id", id);

            var sqlRead = command.ExecuteReader();
            while (sqlRead.Read())
            {
                product.Id = Int32.Parse(sqlRead["Id"].ToString());
                product.Naziv = sqlRead["Naziv"].ToString();
                product.Opis = sqlRead["Opis"].ToString();
                product.Kategorija = sqlRead["Kategorija"].ToString();
                product.Proizvođač = sqlRead["Proizvođač"].ToString();
                product.Dobavljač = sqlRead["Dobavljač"].ToString();
                product.Cena = float.Parse(sqlRead["Cena"].ToString());
            }

            sqlConnection.Close();

            return product;
        }
        public Product UpdateProduct(int id, string naziv, string opis, string kategorija, string proizvodjac, string dobavljac, float cena)
        {
            Product product = new Product();

            product.Id = id;
            product.Naziv = naziv;
            product.Opis = opis;
            product.Kategorija = kategorija;
            product.Proizvođač = proizvodjac;
            product.Dobavljač = dobavljac;
            product.Cena = cena;

            string connectionString = configuration.GetConnectionString("WMTestDatabase");

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UpdateProizvod";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@naziv", naziv);
            command.Parameters.AddWithValue("@opis", opis);
            command.Parameters.AddWithValue("@kategorija", kategorija);
            command.Parameters.AddWithValue("@proizvodjac", proizvodjac);
            command.Parameters.AddWithValue("@dobavljac", dobavljac);
            command.Parameters.AddWithValue("@cena", cena);

            command.ExecuteNonQuery();
            sqlConnection.Close();

            return product;
        }
        public Product InsertProduct(string naziv, string opis, string kategorija, string proizvodjac, string dobavljac, float cena)
        {
            Product product = new Product();

            product.Naziv = naziv;
            product.Opis = opis;
            product.Kategorija = kategorija;
            product.Proizvođač = proizvodjac;
            product.Dobavljač = dobavljac;
            product.Cena = cena;

            string connectionString = configuration.GetConnectionString("WMTestDatabase");

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "InsertProizvod";
            command.Parameters.AddWithValue("@naziv", naziv);
            command.Parameters.AddWithValue("@opis", opis);
            command.Parameters.AddWithValue("@kategorija", kategorija);
            command.Parameters.AddWithValue("@proizvodjac", proizvodjac);
            command.Parameters.AddWithValue("@dobavljac", dobavljac);
            command.Parameters.AddWithValue("@cena", cena);

            command.ExecuteNonQuery();
            sqlConnection.Close();

            return product;
        }
        public Product DeleteProduct(int id)
        {
            Product product = new Product();

            string connectionString = configuration.GetConnectionString("WMTestDatabase");

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var command = sqlConnection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DeleteProizvod";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            sqlConnection.Close();

            return product;
        }
    }
}
