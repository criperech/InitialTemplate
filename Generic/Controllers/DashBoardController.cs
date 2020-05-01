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
           
            //petición de prueba
                var resultWebApi = await webApi.GetAsync<object>("Values");

                return Json(new { success = true, data = new { param1, param2, param3 }, responseWebApi = resultWebApi }, JsonRequestBehavior.AllowGet);
            
           
        }
    }
}