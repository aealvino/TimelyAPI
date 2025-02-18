using Microsoft.AspNetCore.SignalR;
using SeriesServiceApi.DataSource;
using SeriesServiceApi.Interfaces.DataSourse;
using SeriesServiceApi.Interfaces.Services;
using SeriesServiceApi.Models.DTO;
using Mapster;
using System.Runtime.CompilerServices;

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
    public async Task<SeriesEpisodesDTO> GetSeries(int id)
    {
        var series = await _SeriesDataSource.GetSeriesWithEpisodes(x => x.Id == id)
            ?? throw new ArgumentException();

        return series.Adapt<SeriesEpisodesDTO>();
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
        var seriesToDelete = allSeries.FirstOrDefault(allSeries => allSeries.Id == id);

        if (seriesToDelete == null) throw new InvalidOperationException();

        await _SeriesDataSource.RemoveAsync(seriesToDelete);
        await _SeriesDataSource.SaveChangesAsync();
        return seriesToDelete.Id;
    }
}