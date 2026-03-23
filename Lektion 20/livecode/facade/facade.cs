class Facade
{
    private ComplexClass _complexClass = new ComplexClass();

    public Facade()
    {
        
    }

    public void smth()
    {
        _complexClass.smth();
    }
}