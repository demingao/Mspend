using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Api.Models;
using Autofac;
using Microsoft.Ajax.Utilities;
using Mspend.Domain.Entities;
using Mspend.Domain.Interfaces.Services;
using Mspend.Framework.Extensions;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/cat")]
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
            var cats = _categoryService.FindBy().Maps<Category,CategoryModel>();
            return Ok(cats);
        }
       
    }
}
