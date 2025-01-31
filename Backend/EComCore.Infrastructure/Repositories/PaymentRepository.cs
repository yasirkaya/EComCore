using EComCore.Domain.Entities;
using EComCore.Domain.Repositories;
using EComCore.Infrastructure.Data;

namespace EComCore.Infrastructure.Repositories;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(EComCoreDbContext context) : base(context)
    {
    }
}
