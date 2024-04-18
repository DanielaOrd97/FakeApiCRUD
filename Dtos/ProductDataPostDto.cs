using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAppApi.Dtos
{
    public class ProductDataPostDto
    {
        public string title { get; set; } = null!;
        public decimal price { get; set; }
        public string description { get; set; } = null!;
        public int categoryId { get; set; }
        public List<string> images { get; set; } = null!;
    }
}
