using livecode.command;

namespace livecode
{
    class Program
    {
        public static void Main()
        {
            // Create Remote control
            RemoteControl rmt = new RemoteControl();

            // Create Light
            Light light = new Light();

            // Create Command
            OnCommand onCommand = new OnCommand(light);
            OffCommand offCommand = new OffCommand(light);

            // Assign Command
            rmt.SetCommand(0, onCommand);
            rmt.SetCommand(1, offCommand);

            // Activate Commands
            rmt.ButtonPushed(0);
            rmt.ButtonPushed(1);
        }
    }
}