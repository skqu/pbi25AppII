


public class LeaderReport : INetworkReport
{
    public string Title => "Leder rapport (Overblik + Trends)";

    public void Render(NetworkActivitySnapshot snapshot)
    {
        Console.WriteLine($"- Active connections: {snapshot.ActiveConnections}");
        Console.WriteLine($"- Avg port load: {snapshot.AvgPortLoadPercent:0.0}%");
        Console.WriteLine("- Notes: Use for technology and capacity decisions.");
    }
}