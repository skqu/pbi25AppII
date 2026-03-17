namespace solution.command.light
{
    class Light
    {
        public byte brightness
        {
            private set;
            get;
        } = 0;
	public Light()
        {
            
        }

	

        public void On()
        {
		brightness = 100;
            Console.WriteLine("Light is on");
        }

        public void Off()
        {
		brightness = 0;
            Console.WriteLine("Light is off");
        }

	public void Dim(byte bright)
	{
		brightness = bright;
	}
    }
}
