using Api.Models;
using AutoMapper;
using Mspend.Domain.Entities;

namespace Api.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Category, CategoryModel>();
                cfg.CreateMap<MspendRecord, MspendRecordModel>();
                cfg.CreateMap<CategoryModel, Category>();
                cfg.CreateMap<MspendRecordModel, MspendRecord>();
            });
        }
    }
}