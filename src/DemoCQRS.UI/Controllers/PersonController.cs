using AutoMapper;
using DemoCQRS.Application.Commands;
using DemoCQRS.Application.Contracts;
using DemoCQRS.Application.Dtos.Request;
using DemoCQRS.Application.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoCQRS.UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IPersonReadRepository _personReadRepository;
        private readonly IMapper _mapper;

        public PersonController(IMediator mediator,
                                IPersonReadRepository personReadRepository, 
                                IMapper mapper)
        {
            _mediator = mediator;
            _personReadRepository = personReadRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var people = _mapper.Map<IEnumerable<PersonResponseDto>>(await _personReadRepository.ListAsync());
            return View(people);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Telefone")] CreatePersonDto dto)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreatePersonCommand(dto.Name, dto.Email, dto.Telefone));
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var dto = _mapper.Map<UpdatePersonDto>(await _personReadRepository.GetAsync(id));
            if (dto == null)
            {
                return NotFound();
            }
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Name,Email,Telefone")] UpdatePersonDto dto)
        {
            if (id != dto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(new UpdatePersonCommand(dto.Id, dto.Name, dto.Email, dto.Telefone));
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _mapper.Map<PersonResponseDto>(await _personReadRepository.GetAsync(id));

            
            
            return View(person);
        }

        // POST: dtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _mediator.Send(new DeletePersonCommand(id));
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var slide = _mapper.Map<PersonResponseDto>(await _personReadRepository.GetAsync(id));

            if (slide == null)
            {
                return NotFound();
            }

            return View(slide);
        }

    }
}
