

namespace solution.command.light
{
    class OffCommand : ICommand
    {
        private List<string> _history = new List<string>();
        private Light _light;
        public OffCommand(Light light)
        {
            _light = light;
        }

        public void Undo()
        {
            _light.On();
            _history.Add("On");
        }

        public void Execute()
        {
            _light.Off();
            _history.Add("Off");
        }

        public List<string> History()
        {
            return _history;
        }
    }
}