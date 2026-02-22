namespace Multiplicity
{   
    class Engine
    {
        public string Model { get; set; }
        public Engine(string model) { Model = model; }
    }

    class Car
    {
        private Engine _engine;
        
        public Car(Engine engine)
        {
            _engine = engine;
        }

        public string GetEngine()
        {
            return _engine.Model;
        }
    }

    class ECar
    {
        private Engine[] _engines;
        
        public ECar(Engine[] engines)
        {
            _engines = engines;
        }

        public Engine[] GetEngines()
        {
            return _engines;
        }
    }
}