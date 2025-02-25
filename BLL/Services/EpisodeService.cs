using Abstraction.Interfaces.DataSourse;
using Models.Entities;
using Models.DTO;
using Mapster;

namespace SeriesServiceApi.Services
{
    public class EpisodeService : IEpisodesService
    {
        private readonly IGenericDataSourse<Episode> _EpisodesDataSource;

        public EpisodeService(IGenericDataSourse<Episode> seriesDataSource)
        {
            _EpisodesDataSource = seriesDataSource;
        }
        public List<EpisodeDTO> GetAllEpisodes()
        {
            return _EpisodesDataSource.GetElements()
                .ProjectToType<EpisodeDTO>()
                .ToList();
        }
        public async Task<int> AddEpisode(EpisodeDTO episodeDTO)
        {
            var episode = episodeDTO.Adapt<Episode>();
            await _EpisodesDataSource.AddAsync(episode);
            await _EpisodesDataSource.SaveChangesAsync();
            return episodeDTO.Id;
        }

        public async Task<int> UpdateEpisode(EpisodeDTO episodeDTO)
        {
            var episode = episodeDTO.Adapt<Episode>();
            await _EpisodesDataSource.UpdateBase(episode);
            await _EpisodesDataSource.SaveChangesAsync();
            return episodeDTO.Id;
        }
        public async Task<int> DeleteEpisode(int id)
        {
            var episodeToDelete = _EpisodesDataSource.GetElements().FirstOrDefault(x => x.Id == id);
            await _EpisodesDataSource.RemoveAsync(episodeToDelete);
            await _EpisodesDataSource.SaveChangesAsync();
            return id;
        }
    }
}
