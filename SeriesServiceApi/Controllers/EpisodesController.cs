using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Abstraction.Interfaces.DataSourse;
using Microsoft.AspNetCore.Authorization;


namespace SeriesServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodesService _episodeService;

        public EpisodesController(IEpisodesService episodesService)
        {
            _episodeService = episodesService;
        }

        [HttpGet("episodes")]
        [Authorize]
        public List<EpisodeDTO> GetAllSeries()
        {
            return _episodeService.GetAllEpisodes();
        }

        [HttpPost("add-episode")]
        [Authorize]
        public async Task<int> AddEpisode([FromBody] EpisodeDTO episode)
        {
            return await _episodeService.AddEpisode(episode);
        }
        [HttpPut("update-episodes")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<int> UpdateEpisode([FromBody] EpisodeDTO episodeDTO)
        {
            return await _episodeService.UpdateEpisode(episodeDTO);
        }
        [HttpDelete("delete-episode")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<int> DeleteEpisode(int id)
        {
            return await _episodeService.DeleteEpisode(id);
        }
    }
}
