using Code.Command;
using Code.Command.Order;
using Code.Service;

namespace Code
{
    class Program
    {
        public static void Main()
        {
            // Create Invoker
            OrderManager orderManager = new OrderManager();

            // Create Reciever
            OrderService orderService = new OrderService();

            // Create Commands
            CreateCommand createCommand = new CreateCommand(orderService);
            EditCommand editCommand = new EditCommand(orderService);
            DeleteCommand deleteCommand = new DeleteCommand(orderService);

            // Set Commands
            orderManager.SetCommand("create", createCommand);
            orderManager.SetCommand("delete", deleteCommand);
            orderManager.SetCommand("edit", editCommand);

            // Activate Commands
            orderManager.OrderChange("create");
            orderManager.OrderChange("delete");
            orderManager.OrderChange("create");
            orderManager.OrderChange("edit");

            foreach (string cmd in orderManager.GetHistory())
            {
                Console.WriteLine(cmd);
            }
        }
    }
}