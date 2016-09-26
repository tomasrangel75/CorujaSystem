using CorujaPresentation.Controllers;
using CorujaPresentation.DAL;
using System;
using System.Web.Http;

namespace CorujaPresentation.Areas.Especialista.Controllers
{
    public class EspecialistaApiController : BaseApiController
    {

        public EspecialistaApiController(IService service) : base(service) { }        //should be injected

        //USERMAPKEYS

        public IHttpActionResult Get()
        {
            var userMapKeys = Service.UserMapKeys.All();
     //       var models = alunos.Select(ModelFactory.Create);
            return Ok();
        }

        public IHttpActionResult Get(int Id)
        {
            try
            {
                var useMapKey = Service.UserMapKeys.GetById(Id);
          //      var model = ModelFactory.Create(entity);
                  return Ok();
            }
            catch (Exception exc)
            {
                //LOGGING

#if DEBUG
                return InternalServerError(exc);
#endif
                return InternalServerError();

            }

        }


        /*
        //[ModelValidator]
        public IHttpActionResult Post([FromBody]SomeModel EntityModel)
        {
            try
            {
                var someEntity = ModelFactory.Create(entityModel);
                var newEntity = Service.Alunos.AddEntity(Entity);
                Service.Entities.save();

                var model = ModelFactory.Create(newEntity);
                return Created(string.Format("http://localhost:36660/api/EspecilaistaApi/{0}", model.Id), model);

            }
            catch (Exception exc)
            {
                return InternalServerError(exc);
            }

        }
        */

    }
}
