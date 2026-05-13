

public class SecuritySpecialistReport : INetworkReport
{
    public string Title => "Sikkerhedsspecialist rapport (Hændelser + Angreb)";

    public void Render(NetworkActivitySnapshot snapshot)
    {
        Console.WriteLine($"- Failed logins: {snapshot.FailedLogins}");
        Console.WriteLine("- Suspicious IPs:");
        foreach (var ip in snapshot.SuspiciousIps)
            Console.WriteLine($"  * {ip}");

        Console.WriteLine("- Action: Investigate suspicious IPs and correlate with logs.");
    }
}