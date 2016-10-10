using CorujaPresentation.DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CorujaPresentation.Controllers
{
    [RequireHttpsAttribute]
    public class BaseController : Controller
    {
  
    }

  
    public class BaseCtxController : BaseController
    {
        private IUnitOfWork uow;
   
        public BaseCtxController(IUnitOfWork _uow) //should be injected
        {
            uow = _uow; ;
        }

        public IUnitOfWork Uow
        {
            get { return uow; }
        }

        public int IdCurUser
        {
            get {
                var identity = (ClaimsIdentity)User.Identity;
                var idCurUser = identity.FindFirstValue(ClaimTypes.UserData);
                int x = 0;

                if (Int32.TryParse(idCurUser, out x))
                {
                    // you know that the parsing attempt
                    // was successful
                }

                return x; }

        }


    }
}