using Code.Service;

namespace Code.Command.Order
{
    class CreateCommand : ICommand
    {
        private OrderService _order;
        public CreateCommand(OrderService order)
        {
            _order = order;
        }

        public void Execute()
        {
            _order.Create();
        }

        public void Undo()
        {
            
        }

        public string Print()
        {
            return "Create";
        }
    }
}