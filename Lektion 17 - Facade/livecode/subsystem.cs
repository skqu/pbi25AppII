class Subsystem
{
    public Subsystem()
    {
        
    }

    public string Validate(string uname, string pwd)
    {
        if ( (uname == "Stefan") && (pwd == "Secret#1"))
        {
            return "Authorized";         
        }
        return "Unauthorized";
    }
}