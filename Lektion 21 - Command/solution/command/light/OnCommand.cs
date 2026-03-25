namespace solution.command.light
{
    class OnCommand : ICommand
    {
        private List<string> _history = new List<string>();
        private Light _light;
        public OnCommand(Light light)
        {
            _light = light;
        }

        public void Undo()
        {
            _light.Off();
            _history.Add("Off");
        }

        public void Execute()
        {
            _light.On();
            _history.Add("On");
        }
        public List<string> History()
        {
            return _history;
        }
    }
}