using SharedKernel.Domain.Primitives;

namespace Domain.Entities
{
    public class Transaction : Entity
    {

        public List<AccountMovement> AccountMovements { get; set; }
    }
}
