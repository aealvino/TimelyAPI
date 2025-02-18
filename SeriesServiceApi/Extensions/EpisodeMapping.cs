using Mapster;
using SeriesServiceApi.Models.Entities;
using SeriesServiceApi.Models.DTO;

namespace SeriesServiceApi.Extensions
{
    public static class EpisodeMapping
    {
        public static void InitMapping(this IApplicationBuilder app)
        {
            app.EpisodesMapping();
        }

        private static void EpisodesMapping(this IApplicationBuilder app)
        {
            TypeAdapterConfig<EpisodesDTO, Episodes>.NewConfig()
                .Ignore(dest => dest.Series); // Убираем автоматическое создание Series


        }
    }
}