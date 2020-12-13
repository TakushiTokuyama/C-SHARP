using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace WebApplication3
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<Staff, StaffDto>();
            CreateMap<StaffDto, Staff>();
            

        }
    }
}
