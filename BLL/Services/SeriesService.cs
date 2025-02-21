using Abstraction.Interfaces.Services;
using Abstraction.Interfaces.DataSourse;
using Models.DTO;
using Mapster;

public class SeriesService : ISeriesService
{

    private readonly ISeriesDataSourse _SeriesDataSource;

    public SeriesService(ISeriesDataSourse seriesDataSource)
    {
        _SeriesDataSource = seriesDataSource;
    }

    public List<SeriesDTO> GetAllSeries()
    {
        return _SeriesDataSource.GetElements()
            .ProjectToType<SeriesDTO>()
            .ToList();
    }
    public async Task<SeriesDetailsDTO> GetEpisodesSeries(int id)
    {
        var series = await _SeriesDataSource.GetSeriesWithEpisodes(x => x.Id == id)
            ?? throw new InvalidOperationException("Element with current id is not found");

        return series.Adapt<SeriesDetailsDTO>();
    }
    public async Task<int> AddSeries(SeriesDTO seriesDTO)
    {
        var series = seriesDTO.Adapt<Series>();
        series = await _SeriesDataSource.AddAsync(series);
        await _SeriesDataSource.SaveChangesAsync();
        return series.Id;
    }

    public async Task<int> UpdateSeries(SeriesDTO seriesDTO)
    {
        var series = seriesDTO.Adapt<Series>();
        await _SeriesDataSource.UpdateBase(series);
        await _SeriesDataSource.SaveChangesAsync();
        return series.Id;
    }
    public async Task<int> DeleteSeries(int id)
    {
        var allSeries = _SeriesDataSource.GetElements();
        var seriesToDelete = allSeries.FirstOrDefault(allSeries => allSeries.Id == id) 
            ?? throw new InvalidOperationException("Element with current id is not found");

        if (seriesToDelete == null) throw new InvalidOperationException();

        await _SeriesDataSource.RemoveAsync(seriesToDelete);
        await _SeriesDataSource.SaveChangesAsync();
        return seriesToDelete.Id;
    }
}