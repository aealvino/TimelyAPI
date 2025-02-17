using Microsoft.AspNetCore.SignalR;
using SeriesServiceApi.DataSource;
using SeriesServiceApi.Interfaces.DataSourse;
using SeriesServiceApi.Interfaces.Services;
using SeriesServiceApi.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SeriesService : ISeriesService
{

    private readonly IGenericDataSourse<Series> _SeriesDataSource;

    public SeriesService(IGenericDataSourse<Series> seriesDataSource)
    {
        _SeriesDataSource = seriesDataSource;
    }

    public async Task<IEnumerable<SeriesDTO>> GetAllSeries()
    {
        var series = await _SeriesDataSource.GetElements();

        var seriesDTOs = series.Select(s => new SeriesDTO
        {
            Id = s.Id,
            Title = s.Title,
            Genre = s.Genre,
            ReleaseDate = s.ReleaseDate
        }).ToList();

        return seriesDTOs;
    }

    public async Task<int> AddSeries(SeriesDTO seriesDTO)
    {
        var series = new Series(seriesDTO.Title, seriesDTO.Genre, seriesDTO.ReleaseDate, 0);
        await _SeriesDataSource.AddAsync(series);
        await _SeriesDataSource.SaveChangesAsync();
        return series.Id;
    }

    public async Task<int> UpdateSeries(SeriesDTO seriesDTO)
    {
        var seriesList = await _SeriesDataSource.GetElements();
        var existingSeries = seriesList.FirstOrDefault(s => s.Id == seriesDTO.Id);

        existingSeries.Title = seriesDTO.Title;
        existingSeries.Genre = seriesDTO.Genre;
        existingSeries.ReleaseDate = seriesDTO.ReleaseDate;

        await _SeriesDataSource.UpdateBase(existingSeries);
        await _SeriesDataSource.SaveChangesAsync();

        return existingSeries.Id;
    }
    public async Task<int> DeleteSeries(int id)
    {
        var list = await _SeriesDataSource.GetElements();
        var seriesToDelete = list.FirstOrDefault(c => c.Id == id);
        await _SeriesDataSource.RemoveAsync(seriesToDelete);
        await _SeriesDataSource.SaveChangesAsync();
        return id;
    }
}