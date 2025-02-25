using Microsoft.AspNetCore.Mvc;
using Abstraction.Interfaces.Services;
using Models.DTO;
using Microsoft.AspNetCore.Authorization;

namespace SeriesServiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeriesServiceController : ControllerBase
    {
        private readonly ISeriesService _seriesService;

        public SeriesServiceController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        [HttpGet("episodes")]
        [Authorize]
        public async Task<List<SeriesDTO>> GetAllSeries()
        {
            return await Task.FromResult(_seriesService.GetAllSeries());
        }
        /// <summary>
        /// Return specific series id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("series/{id}")]
        [Authorize]
        public async Task<SeriesDetailsDTO> GetEpisodesSeries([FromRoute] int id)
        {
            return await _seriesService.GetEpisodesSeries(id);
        }
        /// <summary>
        /// Return added series id
        /// </summary>
        /// <param name="seriesDTO"></param>
        [HttpPost("add-series")]
        [Authorize]
        public async Task<int> AddSeries([FromBody] SeriesDTO series)
        {
            return await _seriesService.AddSeries(series);
        }
        /// <summary>
        /// Return updated series id
        /// </summary>
        /// <param name="seriesDTO"></param>
        [HttpPut("update-series")]
        [Authorize]
        public async Task<int> UpdateSeries([FromBody] SeriesDTO seriesDTO)
        {
            return await _seriesService.UpdateSeries(seriesDTO);
        }
        /// <summary>
        /// Return deleted series id
        /// </summary>
        /// <param name="seriesDTO"></param>
        [HttpDelete("delete-series")]
        [Authorize(Roles = "User")]
        public async Task<int> DeleteSeries(int id)
        {
            return await _seriesService.DeleteSeries(id);
        }
    }
}
