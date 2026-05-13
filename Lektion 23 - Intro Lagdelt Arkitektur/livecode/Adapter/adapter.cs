class Adapter : ITarget
{
    Adaptee _adaptee = new Adaptee();

    public void smth()
    {
        _adaptee.complexSubSystem();
    }
}