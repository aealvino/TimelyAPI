using Mapster;
using Models.Entities;
using Models.DTO;
using Models.DTO.YourNamespace.DTOs;

namespace SeriesServiceApi.Extensions
{
    public static class MapsterExtention
    {
        public static void InitMapping(this IApplicationBuilder app)
        {
            app.EpisodesMapping();
            app.UserMapping();
        }

        private static void EpisodesMapping(this IApplicationBuilder app)
        {
            TypeAdapterConfig<Episode, EpisodeDTO>.NewConfig()
                .Map(dest => dest.TitleSeries, src => src.Series.Title);

            TypeAdapterConfig<EpisodeDTO, Episode>.NewConfig()
                .Ignore(dest => dest.Series);
        }
        private static void UserMapping(this IApplicationBuilder app)
        {
            TypeAdapterConfig<RegistrationDto, AppUser>.NewConfig()
                .Map(dest => dest.UserName, src => src.Email)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.PasswordHash, src => src.Password);
        }
    }
}