namespace Code.Service.Audit
{
    class Logger
    {
        private static Logger? _log = null;

        private Logger()
        {

        }

        public static Logger GetInst()
        {
            if (_log == null)
            {
                _log = new Logger();
            }
            
            return _log;
        }

        public void Log(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
            {
                return;
            }
            File.AppendAllText("log.txt", $"[{DateTime.Now}] {msg}{Environment.NewLine}");
        }
    }
}