

public class ItSupportReport : INetworkReport
{
    public string Title => "IT-medarbejder rapport (Fejlsøgning + Drift)";

    public void Render(NetworkActivitySnapshot snapshot)
    {
        Console.WriteLine($"- Open ports: {snapshot.OpenPorts}");
        Console.WriteLine($"- Avg port load: {snapshot.AvgPortLoadPercent:0.0}%");
        Console.WriteLine("- Action: Check port utilization and optimize routing/firewall rules.");
    }
}