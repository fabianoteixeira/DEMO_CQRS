using AutoMapper;
using DemoCQRS.Application.Commands;
using DemoCQRS.Application.Contracts.Write;
using DemoCQRS.Application.Dtos.Response;
using DemoCQRS.Application.Events;
using DemoCQRS.Domain.Entities;
using MediatR;

namespace DemoCQRS.Application.Handlers
{
    public class PersonCammandHandler : IRequestHandler<CreatePersonCommand, PersonResponseDto>,
                                        IRequestHandler<UpdatePersonCommand, PersonResponseDto>,
                                        IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonWriteRepository _personWriteRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersonCammandHandler(IPersonWriteRepository personWriteRepository,
                                    IMediator mediator, 
                                    IMapper mapper)
        {
            _personWriteRepository = personWriteRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<PersonResponseDto> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var person = new Person(request.Name, request.Email, request.Telefone);
                await _personWriteRepository.AddAsync(person);

                var createdPerson = _mapper.Map<CreatePersonEvent>(person);

                await _mediator.Publish(createdPerson);

                return _mapper.Map<PersonResponseDto>(person);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<PersonResponseDto> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.Id, request.Name, request.Email, request.Telefone);
            await _personWriteRepository.UpdateAsync(person);

            var uptadePerson = _mapper.Map<UpdatePersonEvent>(person);
            await _mediator.Publish(uptadePerson);

            return _mapper.Map<PersonResponseDto>(person);
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _personWriteRepository.DeleteAsync(request.Id);

            await _mediator.Publish(new DeletePersonEvent(request.Id));

            return true;
        }
    }
}
