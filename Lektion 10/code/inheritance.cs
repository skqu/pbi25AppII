namespace Inheritance
{   
    class Animal
    {
        protected string _name = "";

        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
    }

    class Horse : Animal
    {

    }
}
