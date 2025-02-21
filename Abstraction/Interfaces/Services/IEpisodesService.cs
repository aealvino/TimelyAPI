using Models.DTO;
namespace Abstraction.Interfaces.DataSourse
{
    public interface IEpisodesService
    {
        /// <summary>
        /// Method for getting all Episodes
        /// </summary>
        /// <returns>List of Episodes</returns>
        List<EpisodeDTO> GetAllEpisodes();

        /// <summary>
        /// Method for adding a new Episode
        /// </summary>
        /// <param name="episodeDTO">Episode data to add</param>
        /// <returns>Id of added episodeDTO</returns>
        Task<int> AddEpisode(EpisodeDTO episodeDTO);

        /// <summary>
        /// Method for updating a Episode
        /// </summary>
        /// <param name="episodeDTO">New series data</param>
        /// <returns>Id of updated episodeDTO</returns>
        Task<int> UpdateEpisode(EpisodeDTO episodeDTO);

        /// <summary>
        /// Method for deleting a Episode
        /// </summary>
        /// <param name="id">id of the episode to delete</param>
        /// <returns>Id of deleted EpisodeDTO</returns>
        Task<int> DeleteEpisode(int id);
    }
}
