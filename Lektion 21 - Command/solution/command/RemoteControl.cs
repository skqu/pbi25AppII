namespace solution.command
{
    class RemoteControl
    {
        private ICommand[] _button = new ICommand[]
        {
            new EmptyCommand(),
            new EmptyCommand(),
            new EmptyCommand(),
            new EmptyCommand(),
            new EmptyCommand(),
            new EmptyCommand(),
            new EmptyCommand(),
            new EmptyCommand(),
        };

        public RemoteControl()
        {
            
        }

        public void SetCommand(byte btnNumber, ICommand command)
        {
            _button[btnNumber] = command;
        }

        public void ButtonPushed(byte btnNumber)
        {
            _button[btnNumber].Execute();
        }

        public List<String> ButtonHold(byte btnNumber)
        {
            return _button[btnNumber].History();
        }

    }
}