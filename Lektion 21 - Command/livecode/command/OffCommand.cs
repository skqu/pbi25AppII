using System.Data;

namespace livecode.command
{
    class OffCommand : ICommand
    {
        private Light _light;
        public OffCommand(Light light)
        {
            _light = light;
        }

        public void Undo()
        {
            _light.On();
        }

        public void Execute()
        {
            _light.Off();
        }
    }
}