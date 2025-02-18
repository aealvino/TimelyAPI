using Microsoft.AspNetCore.Mvc;
using SeriesServiceApi.Interfaces.Services;
using SeriesServiceApi.Models.DTO;

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

        [HttpGet(Name = "GetSeries")]
        public async Task<List<SeriesDTO>> GetAllSeries()
        {
            return await Task.FromResult(_seriesService.GetAllSeries());
        }
        [HttpGet("Series/{id}")]
        public async Task<SeriesEpisodesDTO> GetSeries([FromRoute] int id)
        {
            return await _seriesService.GetSeries(id);
        }

        [HttpPost(Name = "PostSeries")]
        public async Task<int> AddSeries([FromBody] SeriesDTO series)
        {
            return await _seriesService.AddSeries(series);
        }
        [HttpPut(Name = "PutSeries: {id}")]
        public async Task<int> UpdateSeries([FromBody] SeriesDTO seriesDTO)
        {
            return await _seriesService.UpdateSeries(seriesDTO);
        }
        [HttpDelete(Name = "DeleteSeries: {id}")]
        public async Task<int> DeleteSeries(int id)
        {
            return await _seriesService.DeleteSeries(id);
        }
    }
}
