using solution.command.light;
using solution.command.fan;
using solution.command;

namespace solution
{
    class Program
    {
        public static void Main()
        {


            // Create Remote control
            RemoteControl rmt = new RemoteControl();

            // Create Light
            Light light = new Light();
            Fan fan = new Fan();

            // Create Command
            OnCommand onCommand = new OnCommand(light);
            OffCommand offCommand = new OffCommand(light);
	        DimUpCommand dimUpCommand = new DimUpCommand(light);
	        DimDownCommand dimDownCommand = new DimDownCommand(light);
            FanOffCommand fanOffCommand = new FanOffCommand(fan);
            FanOnCommand fanOnCommand = new FanOnCommand(fan);

            // Assign Command
            rmt.SetCommand(0, onCommand);
            rmt.SetCommand(1, offCommand);
	        rmt.SetCommand(2, dimUpCommand);
	        rmt.SetCommand(3, dimDownCommand);
            rmt.SetCommand(4, fanOnCommand);
            rmt.SetCommand(5, fanOffCommand);

            // Activate Commands
            rmt.ButtonPushed(0);
            rmt.ButtonPushed(1);
            for (int i = 0; i < 5; i++)
            {
    	        rmt.ButtonPushed(2);
            }
            for (int i = 0; i < 5; i++)
            {
    	        rmt.ButtonPushed(3);
            }

            foreach( string history in rmt.ButtonHold(2))
            {
                Console.WriteLine(history);
            }

            rmt.ButtonPushed(4);
            rmt.ButtonPushed(5);
        }
    }
}
