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
<<<<<<< HEAD
                cfg.CreateMap<Category, CategoryModel>();
                cfg.CreateMap<MspendRecord, MspendRecordModel>();
                cfg.CreateMap<CategoryModel, Category>();
                cfg.CreateMap<MspendRecordModel, MspendRecord>();
=======
                cfg.CreateMap<MspendRecord, MspendRecordModel>();
                cfg.CreateMap<Category, CategoryModel>();
>>>>>>> 662133fc942e02e808162917c4d72e5b412a0ae3
            });
        }
    }
}