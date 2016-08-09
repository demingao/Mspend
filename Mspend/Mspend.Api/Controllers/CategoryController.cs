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
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("cat")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController()
            : this(IocConfig.Container.Resolve<ICategoryService>())
        {

        }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("get")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var cats = _categoryService.FindBy().Maps<Category, CategoryModel>();
            return Ok(cats);
        }

    }
}
