using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Business.Models;
using TestTask.Data;

namespace TestTask.Business.Mapper
{
    public class MapperProfileData : Profile
    {
        public MapperProfileData()
        {
            CreateMap<OrderData, Order>();
            CreateMap<Order, OrderData>();
        }
    }
}
