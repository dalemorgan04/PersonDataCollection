using PersonDataCollection.Models;
using PersonDataCollection.Services;
using PersonDataCollection.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PersonDataCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetClientForm()
        {
            return PartialView("_ClientForm");
        }

        public PartialViewResult GetStaffForm()
        {
            return PartialView("_StaffForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateStaff(StaffViewModel viewModel)
        {
            ViewBag.PersonType = "Staff member";
            if (ModelState.IsValid)
            {
                var staff = new Staff()
                {
                    Forename = viewModel.Forename,
                    Surname = viewModel.Surname,
                    DateOfBirth = viewModel.DateOfBirth
                };

                if (await _personService.CreateStaff(staff))
                {
                    return PartialView("_Success");
                }
            }
            return PartialView("_Fail");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateClient(ClientViewModel viewModel)
        {
            ViewBag.PersonType = "Client";
            if (ModelState.IsValid)
            {
                var client = new Client()
                {
                    Forename = viewModel.Forename,
                    Surname = viewModel.Surname,
                    DateOfBirth = viewModel.DateOfBirth,
                    Address = new Address()
                    {
                        Street = viewModel.Street,
                        Postcode = viewModel.Postcode
                    }
                };

                if (await _personService.CreateClient(client))
                {
                    return PartialView("_Success");
                }
            }
            return PartialView("_Fail");
        }
    }
}