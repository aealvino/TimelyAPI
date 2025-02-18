using Microsoft.AspNetCore.SignalR;
using SeriesServiceApi.DataSource;
using SeriesServiceApi.Interfaces.DataSourse;
using SeriesServiceApi.Interfaces.Services;
using SeriesServiceApi.Models.Entities;
using SeriesServiceApi.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;

namespace SeriesServiceApi.Services
{
    public class EpisodesService : IEpisodesService
    {
        private readonly IGenericDataSourse<Episodes> _EpisodesDataSource;

        public EpisodesService(IGenericDataSourse<Episodes> seriesDataSource)
        {
            _EpisodesDataSource = seriesDataSource;
        }
        public List<EpisodesDTO> GetAllEpisodes()
        {
            return _EpisodesDataSource.GetElements()
                .ProjectToType<EpisodesDTO>()
                .ToList();
        }
        public async Task<int> AddEpisode(EpisodesDTO episodeDTO)
        {
            var episode = episodeDTO.Adapt<Episodes>();
            await _EpisodesDataSource.AddAsync(episode);
            await _EpisodesDataSource.SaveChangesAsync();
            return episodeDTO.Id;
        }

        public async Task<int> UpdateEpisode(EpisodesDTO episodeDTO)
        {
            var episode = episodeDTO.Adapt<Episodes>();
            await _EpisodesDataSource.UpdateBase(episode);
            await _EpisodesDataSource.SaveChangesAsync();
            return episodeDTO.Id;
        }
        public async Task<int> DeleteEpisode(int id)
        {
            var episodeToDelete = _EpisodesDataSource.GetElements()
                .FirstOrDefault(x => x.Id == id);
            await _EpisodesDataSource.RemoveAsync(episodeToDelete);
            await _EpisodesDataSource.SaveChangesAsync();
            return id;
        }
    }
}
