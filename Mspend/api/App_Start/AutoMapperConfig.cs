using Api.Models;
using AutoMapper;
using Mspend.Domain.Entities;

namespace Api
{
    public static class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryModel>().ReverseMap();
                cfg.CreateMap<MspendRecord, MspendRecordModel>().ReverseMap();
                cfg.CreateMap<User, AccoutModel>().ReverseMap();
            });
        }
    }
}