using Application.People.Commands.Create;
using Application.People.Commands.Delete;
using Application.People.Commands.Update;
using Application.People.Queries;
using Domain;
using FluentValidation;
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
            var people = _mediator.Send(query, cancellationToken).Result;

            return View(people);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            return View(await _mediator.Send(new GetPersonByIdQuery(id), cancellationToken));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreatePersonCommand createPersonCommand, CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(createPersonCommand, cancellationToken);
            }
            catch (ValidationException ex)
            {
                foreach (var error in ex.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            return View(createPersonCommand);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return BadRequest();
            }

            return View(await _mediator.Send(new GetPersonByIdQuery((int)id), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePersonCommand updatePersonCommand, CancellationToken cancellationToken)
        {
            await _mediator.Send(updatePersonCommand, cancellationToken);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Person person = await _mediator.Send(new GetPersonByIdQuery((int)id), cancellationToken);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeletePersonCommand deletePersonCommand, CancellationToken cancellationToken)
        {
            await _mediator.Send(deletePersonCommand, cancellationToken);

            return RedirectToAction("Index");
        }
    }
}
