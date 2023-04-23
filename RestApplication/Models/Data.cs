namespace RestApplication.Models
{
    public class Data
    {
        public int CallsPerUserHour { get; set; }
        public int CallsPerUserDay { get; set; }
        public int TokenLifetimeSec { get; set; }
        public int PinTries { get; set; }
        public int CallsPerHour { get; set; }
        public int CallsPerDay { get; set; }
        public bool ReturnOperator { get; set; }
    }
}
