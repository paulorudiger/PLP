using System;

namespace TrabalhoFinalRESTFull.Services.DTOs
{
    public class StockLogDTO
    {
        public long Id { get; set; }

        public int Productid { get; set; }

        public int Qty { get; set; }

        public DateTime Createdat { get; set; }
    }
}
