namespace livecode.command
{
    interface ICommand
    {
        void Undo();
        void Execute();
    }
}