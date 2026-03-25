namespace solution.command.fan
{
    class FanOnCommand : ICommand
    {
        private List<string> _history = new List<string>();
        private Fan _fan;
        
        public FanOnCommand(Fan fan)
        {
            _fan = fan;
        }

        public void Undo()
        {
            _fan.FanOff();
        }

        public void Execute()
        {
            _fan.FanOn();
        }

        public List<string> History()
        {
            return _history;    
        }


    }
}