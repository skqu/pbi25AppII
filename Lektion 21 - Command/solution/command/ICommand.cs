namespace solution.command
{
    interface ICommand
    {
        void Undo();
        void Execute();

        List<string> History();
    }
}