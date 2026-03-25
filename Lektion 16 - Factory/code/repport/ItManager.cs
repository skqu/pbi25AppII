
// 3) Konkrete rapporter (konkrete typer)
public class ItManagerReport : INetworkReport
{
    public string Title => "IT-chef rapport (Sikkerhed + Initiativer)";

    public void Render(NetworkActivitySnapshot snapshot)
    {
        Console.WriteLine($"- Failed logins: {snapshot.FailedLogins}");
        Console.WriteLine($"- Suspicious IPs: {snapshot.SuspiciousIps.Count}");
        Console.WriteLine("- Recommended action: Review access policies and incident log.");
    }
}