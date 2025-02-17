using SeriesServiceApi.Models.Entities;

public class Series
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal BoxOffice { get; set; }
    public ICollection<Episodes> Episodes { get; set; }

    public Series(string title, string genre, DateTime releaseDate, decimal boxOffice)
    {
        Title = title;
        Genre = genre;
        ReleaseDate = releaseDate;
        BoxOffice = boxOffice;
    }
}
