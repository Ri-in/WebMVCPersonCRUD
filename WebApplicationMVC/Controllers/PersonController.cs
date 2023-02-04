using Application.People.Commands;
using Application.People.Queries;
using Azure.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
            var people = _mediator.Send(query, cancellationToken).Result;

            return View(people);
        }

        [HttpGet]
        public IActionResult Get(int id, CancellationToken cancellationToken)
        {
            return View(GetPersonById(id, cancellationToken));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] Person person, CancellationToken cancellationToken)
        {
            int id = _mediator.Send(new CreatePersonCommand(person.FirstName, person.LastName, person.Age), cancellationToken).Result;

            return View(id);
        }

        [HttpGet]
        public IActionResult Update(int id, CancellationToken cancellationToken)
        {
            return View(GetPersonById(id, cancellationToken));
        }

        [HttpPost]
        public IActionResult Update([FromForm] Person person, CancellationToken cancellationToken)
        {
            _mediator.Send(new UpdatePersonCommand(person.Id, person.FirstName, person.LastName, person.Age));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id, CancellationToken cancellationToken)
        {
            return View(GetPersonById(id, cancellationToken));
        }

        [HttpPost]
        public IActionResult DeletePost(int id, CancellationToken cancellationToken)
        {
            _mediator.Send(new DeletePersonCommand(id), cancellationToken);

            return RedirectToAction("Index");
        }
        

        private Person GetPersonById(int id, CancellationToken cancellationToken)
        {
            return _mediator.Send(new GetPersonByIdQuery(id), cancellationToken).Result;
        }
    }
}
