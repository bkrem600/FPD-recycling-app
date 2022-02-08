    namespace UWS.Shared
{
    public class FPD
    {
        public int ID { get; set; }
        
        public int? Size { get; set; }
        public string? Make { get; set; }
        
        public string? ModelCode { get; set; }
        public int? Year { get; set; }
        public string? Origin { get; set; }
        public string? FrontCasingSorting { get; set; }
        public string? BackCasingSorting { get; set; }

        //related entities
        public Category? Category { get; set; }
        public int CategoryID { get; set; }
    }
}