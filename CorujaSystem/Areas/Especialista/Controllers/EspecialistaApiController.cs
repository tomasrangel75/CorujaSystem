//using CorujaSystem.Controllers;
//using CorujaSystem.DAL;
//using CorujaSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace CorujaSystem.Areas.Especialista.Controllers
//{
//    public class EspecialistaApiController : BaseApiController
//    {        public EspecialistaApiController() { }
//        public EspecialistaApiController(IService service) : base(service) { }        //should be injected
        
//        [HttpPost]
//        public HttpResponseMessage UtilizaChave(string Kcode)
//        {

//            //Valida Chave
//            var keys = Service.ReportKeys.All(); 

//            var exist = (from x in keys
//                         where x.KeyCode.Equals(Kcode)
//                         select x).Count();  
                       
//            if (exist == 0) // se existe
//            {
//                return Request.CreateResponse(HttpStatusCode.NotFound);
//            }
//            else // se esta ativa
//            {
//                // if ativa
//                //return Request.CreateResponse(HttpStatusCode.BadRequest);

//                //else
//                // inativa
//                // pega o numero de relatorios

//            }

//         ////////////////////////////////////////////////////////////////////            

//            try // acrescenta mais relatorios ao usuario
//            {
//                var usrs = Service.ApplicationUsers;
//                var usr = from x in usrs.All()
//                          where x.Email.Equals(User.Identity.Name.ToString())
//                          select x;
                
//            }
//            catch (Exception ex)
//            {
//                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
//            }

//            return Request.CreateResponse(HttpStatusCode.OK);
            
//        }

//        [HttpGet]
//        public IEnumerable<string> ListaResultados()
//        {
//            // check user
//            // retorna seus arquivos de resultados
//            IList<string> lst = new List<string>();
//            lst.Add("ll");

//            return lst;
//        }

//        [HttpGet]
//        public IEnumerable<string> ListaRelatorios()
//        {
//            // check user
//            // retorna seus arquivos de relatorios
//            IList<string> lst = new List<string>();
//            lst.Add("ll");

//            return lst;
//        }

//        [HttpGet]
//        public int RelatoriosDisponiveis()
//        {
//            // check user
//            // retorna num de relatorios disponiveis
//            return 1;
//        }

//        [HttpGet]
//        public int RelatoriosUtilizados()
//        {
//            // check user
//            // retorna num de relatorios utilizados
//            return 1;
//        }

//        [HttpGet]
//        public IEnumerable<string> ListarChaves()
//        {
//            // check user
//            // retorna seus arquivos de relatorios
//            IList<string> lst = new List<string>();
//            lst.Add("ll");

//            return lst;
//        }

//        [HttpGet]
//        public IEnumerable<string> ListarChaves(int id) // ativa ou inativa
//        {
//            // check user
//            // retorna seus arquivos de relatorios
//            IList<string> lst = new List<string>();
//            lst.Add("ll");

//            return lst;
//        }

//        //[ModelValidator]
//        [HttpPost]
//        public IHttpActionResult CadastrarChave([FromBody]ReportKey EntityModel)
//        {
//            try
//            {
//                //var someEntity = ModelFactory.Create(entityModel);
//                //var newEntity = Service.Alunos.AddEntity(Entity);
//                //Service.Entities.save();

//                //var model = ModelFactory.Create(newEntity);
//                // return Created(string.Format("http://localhost:36660/api/EspecilaistaApi/{0}", model.Id), model);
//                return Created(string.Format("http://localhost:36660/api/EspecilaistaApi/{0}"),"oo");

//            }
//            catch (Exception exc)
//            {
//                return InternalServerError(exc);
//            }

//        }

//        [HttpPost]
//        public IHttpActionResult AtivarInativarChave(bool isAct)
//        {
//            try
//            {
//                //var someEntity = ModelFactory.Create(entityModel);
//                //var newEntity = Service.Alunos.AddEntity(Entity);
//                //Service.Entities.save();

//                //var model = ModelFactory.Create(newEntity);
//                return Created(string.Format("http://localhost:36660/api/EspecilaistaApi/{0}"), "oo");

//            }
//            catch (Exception exc)
//            {
//                return InternalServerError(exc);
//            }

//        }






//    }
//}
