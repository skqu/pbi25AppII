namespace livecode.command
{
    class OnCommand : ICommand
    {
        private Light _light;
        public OnCommand(Light light)
        {
            _light = light;
        }

        public void Undo()
        {
            _light.Off();
        }

        public void Execute()
        {
            _light.On();
        }
    }
}