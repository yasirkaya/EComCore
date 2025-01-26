using MediatR;

namespace EComCore.Application.AddressOperations.Commands
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        public CreateAddressCommandHandler()
        {
        }

        public Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}