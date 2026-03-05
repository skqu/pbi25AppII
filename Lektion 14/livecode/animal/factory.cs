class Factory
{
    private IAnimal? _animal = null;

    public Factory()
    {
        
    } 

    public IAnimal? Create(string type)
    {
        switch(type)
        {
            case "Dog":
                _animal = new Dog();
            break;
            case "Cat":
                _animal = new Cat();
            break;
            case "Fish": 
                _animal = new Fish();
            break;
            default:
                _animal = null;
            break;
        }
        return _animal;
    }
}