using Saguir.Core.Filters;
using Saguir.ViewModels;
using System.Web.Mvc;

namespace Saguir.Controllers
{
    [UserAuthentication]
    public class DashBoardController : Controller
    {
        DashBoardVM viewModel;

        public DashBoardController(DashBoardVM vm)
        {
            this.viewModel = vm;

        }

        // GET: DashBoard
        public ActionResult Index()
        {
            this.viewModel.Propiedad = "Init Template - viewModel Works!";

            return View(this.viewModel);
        }
    }
}