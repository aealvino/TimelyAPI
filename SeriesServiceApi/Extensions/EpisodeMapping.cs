using Mapster;
using Models.Entities;
using Models.DTO;

namespace SeriesServiceApi.Extensions
{
    public static class EpisodeMapping
    {
        public static void InitMapping(this IApplicationBuilder app)
        {
            app.AppMapping();
        }

        private static void AppMapping(this IApplicationBuilder app)
        {
            TypeAdapterConfig<Episode, EpisodeDTO>.NewConfig()
                .Map(dest => dest.TitleSeries, src => src.Series.Title);

            TypeAdapterConfig<EpisodeDTO, Episode>.NewConfig()
                .Ignore(dest => dest.Series);

            TypeAdapterConfig<RegistrationModel, AppUser>
                .NewConfig()
                .Map(dest => dest.UserName, src => src.Email);
        }
    }
}