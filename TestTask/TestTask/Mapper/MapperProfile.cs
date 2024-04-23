using AutoMapper;
using TestTask.Business.Models;
using TestTask.Models.ViewModel;

namespace TestTask.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OrderData, OrderViewModel>();
            CreateMap<OrderViewModel, OrderData>();
        }
    }
}
