using FakeAppApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FakeAppApi.Services
{
    public class FakeApiService
    {
        public string url = "https://api.escuelajs.co/api/v1/";
        HttpClient client;

        public async Task<List<ProductData>> GetProducts()
        {
            client = new();
            var response = await client.GetAsync($"{url}products");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var productdata = JsonSerializer.Deserialize<List<ProductData>>(json.ToString());
            return productdata;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            client = new();
            var response = await client.GetAsync($"{url}categories/");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var categorydata = JsonSerializer.Deserialize<List<CategoryDto>>(json.ToString());
            return categorydata;
        }

        public async Task CreateProducts(ProductDataPostDto p, string img)
        {
            client = new();
            var destino = new Uri($"{url}products/");
            //var listimg = img.Split(',').Select(url => url.Trim()).ToList();
            var listimg = img.Split(',')
                 .Select(url => url.Trim())
                 .Where(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                 .ToList();


            var productData = new ProductDataPostDto()
            {
                title = p.title,
                price = p.price,
                description = p.description,
                categoryId = p.categoryId,
                images = listimg
            };

            var newpostJson = JsonSerializer.Serialize(productData);
            var content = new StringContent(newpostJson, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(destino, content);

            if (result.IsSuccessStatusCode)
            {
                var resultcontent = await result.Content.ReadAsStringAsync();
            }

        }

         public async Task UpdateProducts(ProductDataPutDto product,int id)
         {
            client = new();
            var destino = new Uri($"{url}products/{id}");

            var productData = new ProductDataPutDto()
            {
                title = product.title,
                price = product.price
            };

            var newputJson = JsonSerializer.Serialize(productData);
            var content = new StringContent(newputJson, Encoding.UTF8, "application/json");
            var result = await client.PutAsync(destino, content);

            if (result.IsSuccessStatusCode)
            {
                var resultcontent = await result.Content.ReadAsStringAsync();
            }
         }

         
        public async Task DeleteProducts(int id)
        {
            client = new();
            var destino = new Uri($"{url}products/{id}");

            var result = await client.DeleteAsync(destino);

        }

       


    }
}
