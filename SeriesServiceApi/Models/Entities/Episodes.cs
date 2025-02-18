namespace SeriesServiceApi.Models.Entities
{
    public class Episodes
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Duration { get; set; }
        public int SeriesID { get; set; }
        public Series? Series { get; set; }
    }
}
