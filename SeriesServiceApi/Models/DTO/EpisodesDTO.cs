namespace SeriesServiceApi.Models.DTO
{
    public class EpisodesDTO
    {
        /// <summary>
        /// Id for Episode
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title of Episode
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Duration of Episode
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Id of the Series
        /// </summary>
        public int SeriesID { get; set; }
        /// <summary>
        /// Title of Series
        /// </summary>
        public string TitleSeries { get; set; }
    }
}
