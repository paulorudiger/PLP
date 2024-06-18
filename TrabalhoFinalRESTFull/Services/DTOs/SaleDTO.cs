using System.Collections.Generic;
using System;

namespace TrabalhoFinalRESTFull.Services.DTOs
{
    public class SaleDTO
    {
        public string Code { get; set; }
        public DateTime Createat { get; set; }
        public int Productid { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
    }

    public class SaleReportDTO
    {
        public string Code { get; set; }
        public List<SaleItemDTO> Sales { get; set; }
    }

    public class SaleItemDTO
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public DateTime Date { get; set; }
    }
}
