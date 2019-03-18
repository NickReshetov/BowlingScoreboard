using AutoMapper;
using BowlingScoreboard.DataAccess.EntityFramework.Entities;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.DataAccess.Mappings
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>().ReverseMap();
        }
    }
}
