﻿namespace RouletteAPI.Models
{
    public class RouletteModel :BaseModel
    {

        public string BetOn { get; set; } 
        public int Token { get; set; }
        public string Color { get; set; }
        public string EvenOdd { get; set; }
        public string GroupBetID { get; set; }
       
    }
}
