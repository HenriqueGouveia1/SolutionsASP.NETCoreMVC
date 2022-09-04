using Capitulo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capitulo1.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<InstituicaoModel> instituicoes = new List<InstituicaoModel>()
        {
            new InstituicaoModel()
            {
                InstituicaoId = 0,
                Nome = "Unipe",
                Endereco = "Rua ali"
            }, 
            new InstituicaoModel()
            {
                InstituicaoId = 1,
                Nome = "FPB",
                Endereco = "Rua ala"
            } ,
            new InstituicaoModel()
            {
                InstituicaoId = 2,
                Nome = "UNIESP",
                Endereco = "Rua alibaba"
            }

        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }

        //GET Create 
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstituicaoModel instituicao)
        {
            instituicoes.Add(instituicao);
            instituicao.InstituicaoId = instituicoes.Select(i => i.InstituicaoId).Max() + 1;

            return RedirectToAction("Index");
        }
    }
}
