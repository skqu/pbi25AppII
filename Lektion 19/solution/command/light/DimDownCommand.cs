
namespace solution.command.light
{
    class DimDownCommand : ICommand
    {
        private Light _light;
        private List<string> _history = new List<string>();
        private byte _state = 0;
        private byte _prevState = 0;
        public DimDownCommand(Light light)
        {
            _light = light;
        }

        public void Undo()
        {
		    byte tmpState = _state;
		    _state = _prevState;
		    _prevState = tmpState;
            _light.Dim(_state);
        }

        public void Execute()
        {
            _state = _light.brightness;
		    _prevState = _state;
            if (_state > 0)
            {
		        _state -= 1; 
            }
            _light.Dim(_state);
            _history.Add(_state.ToString());
            Console.WriteLine(_state);
        }

        public List<string> History()
        {
            return _history;
        }
    }
}
