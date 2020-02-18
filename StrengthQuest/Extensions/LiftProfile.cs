using AutoMapper;
using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModels;

namespace Extensions
{
    public class LiftProfile : Profile, ILiftMapper
    {
        public LiftProfile()
        {
            CreateMap<Lift, LiftViewModel>();
        }
    }
}
