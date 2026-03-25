
class Animal
{
    protected string _sound;
    private bool _feather;
    public byte beak; 
    internal byte _legs;

    public Animal(byte legs)
    {
        _sound = "Quack"; 
        _feather = false;
        beak = 1; 
        _legs = legs;
    } 

    private bool GetFeather() 
    { 
        return _feather;
    }

    public string GetSound() 
    {
        return _sound;
    }

    public byte GetLeg()   
    {
        return _legs;
    }

    public byte GetBeak() 
    { 
        return beak; 
    }
}