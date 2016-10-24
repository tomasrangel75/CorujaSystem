using CorujaSystem.Controllers;
using CorujaSystem.DAL;
using CorujaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CorujaSystem.Areas.Especialista.Controllers
{
    public class AmbienteController : BaseCtxController
    {

        public AmbienteController() { }

        public AmbienteController(IUnitOfWork uow) : base(uow) { }   //should be injected
    
        #region Load pages

        public ActionResult SobreEspecialista()
        {
            return View();
        }

        public ActionResult Avaliacoes()
        {
            return View();
        }

        public ActionResult Relatorios()
        {
            return View();
        }

        public ActionResult Resultados()
        {
            return View();
        }

        public ActionResult Ajuda()
        {
            return View();
        }

        #endregion

        [HttpPost]
        public ActionResult UtilizaChave(string Kcode)
        {

            //Valida Chave
            var rptKeys = Uow.GetRepository<ReportKey>().All();
            var rptKey = (from x in rptKeys
                          where x.KeyCode.Equals(Kcode)
                          select x).FirstOrDefault();

            // se esta ativa
            if (rptKey == null)
            {
                ViewBag.KeyUsed = "Licença inválida";
                return View("Relatorios");
            }
            else // se esta ativa
            {
                if (rptKey.IsActive == true)
                {
                    // checkProfile => se não tem adiciona user
                    var user = User.Identity.GetUserId();
                    Uow.SetUpProfile(1, user, "Especialista");

                    //inativa
                    rptKey.IsActive = false;

                    // associa user e licença 
                    var userMapKey = new UserMapKey() { IdKey = rptKey.Id, IdUser = IdCurUser };
                    Uow.GetRepository<UserMapKey>().Add(userMapKey);

                    ViewBag.KeyUsed = "Foram adicionados " + rptKey.ReportNumber.ToString() + " relatórios à sua conta";
                    return View("Relatorios");

                }
                else //inativa
                {
                    ViewBag.KeyUsed = "Essa licença já foi utilizada";
                    return View("Relatorios");

                }

            }

        }

        [HttpGet]
        public ActionResult ListaResultados()
        {
            // retorna arquivos de resultados
            var fls = Uow.GetRepository<UserFile>().All().Select(f => f.IdUser == IdCurUser);
            return View("Resultados",fls);
        }

        [HttpGet]
        public ActionResult ListaRelatorios()
        {
            // retorna lista de relatorios gerados
            var rlts = Uow.GetRepository<Report>().All().Select(f => f.RptFileResult.IdUser == IdCurUser);
            return View("Relatorios",rlts);
        }

        [HttpGet]
        public int RelatoriosDisponiveis()
        {
            // retorna num de relatorios disponiveis
            var rlts = Uow.GetRepository<Report>().All().Select(f => f.RptFileResult.IdUser == IdCurUser);
            return 1;
        }
        

    }




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


}