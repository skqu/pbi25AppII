using Code.Service;

namespace Code.Command.Order
{
    class DeleteCommand : ICommand
    {
        private OrderService _order;
        public DeleteCommand(OrderService order)
        {
            _order = order;
        }

        public void Execute()
        {
            _order.Delete();
        }

        public void Undo()
        {
            
        }

        public string Print()
        {
            return "Delete";
        }
    }
}