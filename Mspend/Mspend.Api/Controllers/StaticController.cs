using System.Collections.Generic;
using System.Web.Http;
using Autofac;
using Mspend.Api.Filters;
using Mspend.Api.Models;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Extensions;

namespace Mspend.Api.Controllers
{
    [Authorize]
    [AppExceptionFilter]
    [RoutePrefix("static")]
    public class StaticController : ApiController
    {
         private readonly ICategoryService _categoryService;

         public StaticController()
            : this(IocConfig.Container.Resolve<ICategoryService>())
        {

        }
         public StaticController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("searchmodel")]
        [HttpGet]
        public IHttpActionResult SearchModel()
        {
            var cats = _categoryService.FindBy().Maps<Category, CategoryModel>();
            var dateTypes = new List<DateModel>()
            {
                new DateModel(){Id=0,Name="全部"},
                new DateModel(){Id=1,Name="最近一周"},
                new DateModel(){Id=2,Name="最近两周"},
                new DateModel(){Id=3,Name="最近三周"},
                new DateModel(){Id=4,Name="最近一个月"},
                new DateModel(){Id=5,Name="最近两个月"},
                new DateModel(){Id=6,Name="最近三个月"}
            };
            return Ok(new{Cats=cats,DateTypes=dateTypes});
        }
    }
}
