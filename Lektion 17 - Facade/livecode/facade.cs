class Facade
{
    private Subsystem _subsystem;
    public Facade()
    {
        _subsystem = new Subsystem();
    }

    public string Login(string uanme, string pwd)
    {
        return _subsystem.Validate(uanme, pwd);

    }
}