using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;


        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
