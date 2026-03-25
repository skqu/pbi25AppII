class Client
{
    public Client()
    {
        ITarget adapter = new Adapter();

        adapter.smth();
    }
}