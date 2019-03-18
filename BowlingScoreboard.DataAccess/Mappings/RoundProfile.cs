using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BowlingScoreboard.DataAccess.EntityFramework.Entities;
using BowlingScoreboard.Dtos;

namespace BowlingScoreboard.DataAccess.Mappings
{
    public class RoundProfile : Profile
    {
        public RoundProfile()
        {
            CreateMap<Round, RoundDto>().ReverseMap();

            CreateMap<RoundType, RoundTypeDto>().ReverseMap();

            CreateMap<Roll, RollDto>().ReverseMap();
        }
    }
}
