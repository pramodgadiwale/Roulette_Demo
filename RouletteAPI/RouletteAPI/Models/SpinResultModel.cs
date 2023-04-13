namespace RouletteAPI.Models
{
    public class SpinResultModel :BaseModel
    {
        public int WinningNumber { get; set; }   
        public string Color { get; set; }
        public string EvenOdd { get; set; }               
    }
}
