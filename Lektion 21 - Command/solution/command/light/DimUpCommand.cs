namespace solution.command.light
{
    class DimUpCommand : ICommand
    {
        private List<string> _history = new List<string>();
        private Light _light;
	    private byte _state = 0;
	    private byte _prevState = 0;
        public DimUpCommand(Light light)
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
            if( _state < 100 )
            {
    		    _state += 1; 
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
