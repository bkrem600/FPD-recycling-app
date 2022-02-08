using System.Collections.Generic;

namespace UWS.Shared
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; } 

        //related entities
        public ICollection<FPD>? FPDs { get; set; }
    }
}