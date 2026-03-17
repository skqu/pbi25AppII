namespace Code.Command
{
    class OrderManager
    {

        private Dictionary<string,ICommand> _commands = new Dictionary<string, ICommand>();
        private List<ICommand> _history = new List<ICommand>();
        public OrderManager()
        {
            
        }

        public void SetCommand(string key, ICommand val)
        {
            _commands[key] = val;
        }

        public void OrderChange(string key)
        {
            if (_commands.ContainsKey(key))
            {
                ICommand cmd = _commands[key];
                cmd.Execute();
                _history.Add(cmd);
            }
            else
            {
                Console.WriteLine($"Command '{key}' not found.");
            }
        }

        public List<string> GetHistory()
        {
            List<string> rtn = new List<string>();

            foreach (ICommand command in _history)
            {
                rtn.Add(command.Print());
            }

            return rtn;
        }


    }
}