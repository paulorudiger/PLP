using System;

namespace TrabalhoFinalRESTFull.Services.DTOs
{
    public class StockLogDTO
    {
        public int Productid { get; set; }
        public int Qty { get; set; }
        public DateTime Createdat { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
    }
}
