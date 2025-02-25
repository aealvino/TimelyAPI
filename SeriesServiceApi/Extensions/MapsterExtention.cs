using Mapster;
using Models.Entities;
using Models.DTO;

namespace SeriesServiceApi.Extensions
{
    public static class MapsterExtention
    {
        public static void InitMapping(this IApplicationBuilder app)
        {
            app.EpisodesMapping();
        }

        private static void EpisodesMapping(this IApplicationBuilder app)
        {
            TypeAdapterConfig<Episode, EpisodeDTO>.NewConfig()
                .Map(dest => dest.TitleSeries, src => src.Series.Title);

            TypeAdapterConfig<EpisodeDTO, Episode>.NewConfig()
                .Ignore(dest => dest.Series);
        }
    }
}