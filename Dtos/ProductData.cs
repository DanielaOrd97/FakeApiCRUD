//using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAppApi.Dtos
{
    public class ProductData
    {
        public int id { get; set; }
        public string title { get; set; } = null!;
        public decimal price { get; set; }
        public string description { get; set; } = null!;
        public category category { get; set; } = new();
        public List<string>? images { get; set; }
    }

    public class category
    {
        public int id { get; set; } 
        public string? name { get; set; }
        public string? image { get; set; }
    }
}
