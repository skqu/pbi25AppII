namespace solution.command
{
    class EmptyCommand : ICommand
    {
        public EmptyCommand()
        {
        }

        public void Undo()
        {
            
        }

        public void Execute()
        {
        }

        public List<string> History()
        {
            return new List<string>();
        }
    }
}