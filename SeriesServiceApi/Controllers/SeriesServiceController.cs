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

        [HttpGet(Name = "GetSeriesService")]
        public async Task<IEnumerable<SeriesDTO>> GetAllSeries()
        {
            return await _seriesService.GetAllSeries();
        }

        [HttpPost(Name = "PostSeries")]
        public async Task<int> AddSeries([FromBody] SeriesDTO seriesDTO)
        {
            return await _seriesService.AddSeries(seriesDTO);
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
