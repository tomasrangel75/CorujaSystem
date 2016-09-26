using CorujaPresentation.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace CorujaPresentation.Controllers
{

    [RequireHttpsAttribute]
    public abstract class BaseApiController : ApiController
    {
        private readonly IService srv;
        //private IModelFactory mf;

        public BaseApiController(IService service) //should be injected
        {
            srv = service;
        }

        //public IModelFactory ModelFactory
        //{
        //    get
        //    {
        //        if (mf == null)
        //            mf = new ModelFactory(Request);
        //        return mf;
        //    }
        //}

        public IService Service
        {
            get { return srv; }
        }



    }
}
