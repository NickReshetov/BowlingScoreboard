using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BowlingScoreboard.DataAccess.EntityFramework.Entities;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.DataAccess.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>().ReverseMap();
        }
    }
}
