namespace RouletteAPI.Models
{
    public class BaseModel
    {
        public string SessionID { get; set; }
        public string User { get; set; }
        public DateTime DateTime { get; set; }
        public string AppName { get; set; }
    }
}
