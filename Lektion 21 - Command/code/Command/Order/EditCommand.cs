using Code.Service;

namespace Code.Command.Order
{
    class EditCommand : ICommand
    {
        private OrderService _order;
        public EditCommand(OrderService order)
        {
            _order = order;
        }

        public void Execute()
        {
            _order.Edit();
        }

        public void Undo()
        {
            
        }

        public string Print()
        {
            return "Edit";
        }
    }
}