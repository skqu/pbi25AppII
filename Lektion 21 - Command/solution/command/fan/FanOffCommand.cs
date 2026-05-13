namespace solution.command.fan
{
    class FanOffCommand : ICommand
    {
        private List<string> _history = new List<string>();
        private Fan _fan;
        
        public FanOffCommand(Fan fan)
        {
            _fan = fan;
        }

        public void Undo()
        {
            _fan.FanOn();
        }

        public void Execute()
        {
            _fan.FanOff();
        }

        public List<string> History()
        {
            return _history;    
        }


    }
}