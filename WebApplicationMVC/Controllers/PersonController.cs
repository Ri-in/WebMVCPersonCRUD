using Application.People.Queries;
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


        public IActionResult Index(GetPersonListQuery query, CancellationToken cancellationToken)
        {
            var people = _mediator.Send(query, cancellationToken).Result.ToList();

            return View(people);
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
