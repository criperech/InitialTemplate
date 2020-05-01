using ModelStructure.Core.Misc;
using Saguir.Core.Filters;
using Saguir.Core.Services;
using Saguir.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Saguir.Controllers
{
    [UserAuthentication]
    public class DashBoardController : Controller
    {
        readonly DashBoardVM viewModel;
        private readonly IWebApiCoreService webApi;


        public DashBoardController(DashBoardVM vm, IWebApiCoreService webApi)
        {
            this.viewModel = vm;
            this.webApi = webApi;
        }

        // GET: DashBoard
        public ActionResult Index()
        {
            this.viewModel.Propiedad = "Init Template - viewModel Works!";
            this.viewModel.Objeto = new { Id = 1, Name = "Prueba", Equis = false };

            return View(this.viewModel);
        }

        public async Task<JsonResult> TestConectWithApi(string param1, int param2, bool param3)
        {
            try
            {
                var resultWebApi = await webApi.GetAsync<TestApi>("Values");

                return Json(new { success = true, data = new { param1, param2, param3 }, resultWebApi }, JsonRequestBehavior.AllowGet);

            }
            catch (System.Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                throw;
            }
        }
    }
}