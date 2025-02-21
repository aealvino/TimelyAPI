using Models.DTO;

namespace Abstraction.Interfaces.Services
{
    public interface ISeriesService
    {
        /// <summary>
        /// Method for getting all Series
        /// </summary>
        /// <returns>List of SeriesDTO</returns>
        List<SeriesDTO> GetAllSeries();

        Task<SeriesDetailsDTO> GetEpisodesSeries(int id);

        /// <summary>
        /// Method for adding a new Series
        /// </summary>
        /// <param name="seriesDTO">Series data to add</param>
        /// <returns>Id of added seriesDTO</returns>
        Task<int> AddSeries(SeriesDTO seriesDTO);

        /// <summary>
        /// Method for updating a Series
        /// </summary>
        /// <param name="id">Id of the series to update</param>
        /// <param name="seriesDTO">New series data</param>
        /// <returns>Id of updated seriesDTO</returns>
        Task<int> UpdateSeries(SeriesDTO seriesDTO);

        /// <summary>
        /// Method for deleting a Series
        /// </summary>
        /// <param name="id">id of the series to delete</param>
        /// <returns>Id of deleted SeriesDTO</returns>
        Task<int> DeleteSeries(int id);
    }
}