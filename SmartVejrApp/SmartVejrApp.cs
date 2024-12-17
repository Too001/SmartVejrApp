namespace SmartVejrApp
{
    public class Weather
    {
        public int Id { get; set; }
        public int Tempature { get; set; }
        public int Humidity { get; set; }
        public DateTime Timestamp { get; set; }

        public override string ToString()
        {
            return $"{Id} {Tempature} {Humidity} {Timestamp}";
        }
    }
}
