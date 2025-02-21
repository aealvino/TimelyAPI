namespace Models.DTO
{
    public class SeriesDTO
    {
        /// <summary>
        /// Id of the Series
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Title of the Series
        /// </summary>
        public string? Title {  get; set; }
        /// <summary>
        /// Genres of the Series
        /// </summary>
        public string? Genre { get; set; }
        /// <summary>
        /// Release Date of Series
        /// </summary>
        public DateTime ReleaseDate { get; set; }
    }
}
