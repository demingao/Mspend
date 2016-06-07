using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Models;
using Autofac;

using Mspend.Domain.Interfaces.Services;

namespace Api.Controllers
{
    [RoutePrefix("api/mr")]
    public class MspendRecodrController : ApiController
    {
        private IMspendRecordService _mspendRecordService;

        public MspendRecodrController()
            : this(IocConfig.Container.Resolve<IMspendRecordService>())
        {

        }
        public MspendRecodrController(IMspendRecordService mspendRecordService)
        {
            _mspendRecordService = mspendRecordService;
        }
        [Route("create")]
        [HttpGet]
        public IHttpActionResult Create()
        {
           // var cats = _categoryService.FindBy();
            return Ok();
        }
       
    }
}
