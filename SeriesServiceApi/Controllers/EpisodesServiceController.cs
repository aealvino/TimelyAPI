using Microsoft.AspNetCore.Mvc;
using SeriesServiceApi.Interfaces.Services;
using SeriesServiceApi.Models.DTO;
using SeriesServiceApi.Models.Entities;

namespace SeriesServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesServiceController : ControllerBase
    {
        private readonly IEpisodesService _episodeService;

        public EpisodesServiceController(IEpisodesService episodesService)
        {
            _episodeService = episodesService;
        }

        [HttpGet(Name = "GetEpisodeService")]
        public async Task<List<EpisodesDTO>> GetAllSeries()
        {
            return await Task.FromResult(_episodeService.GetAllEpisodes());
        }

        [HttpPost(Name = "PostEpisode")]
        public async Task<int> AddEpisode([FromBody] EpisodesDTO episode)
        {
            return await _episodeService.AddEpisode(episode);
        }
        [HttpPut(Name = "PutEpisode: {id}")]
        public async Task<int> UpdateEpisode([FromBody] EpisodesDTO episodeDTO)
        {
            return await _episodeService.UpdateEpisode(episodeDTO);
        }
        [HttpDelete(Name = "DeleteEpisode: {id}")]
        public async Task<int> DeleteEpisode(int id)
        {
            return await _episodeService.DeleteEpisode(id);
        }
    }
}
