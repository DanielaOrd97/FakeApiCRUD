using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeAppApi.Dtos
{
    public class ProductDataPutDto
    {
        public string title { get; set; } = null!;
        public decimal price { get; set; }
    }
}
