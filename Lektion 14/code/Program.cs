

// 4) Rollen (input til Factory)
public enum UserRole
{
    ItManager,
    Leader,
    SecuritySpecialist,
    ItSupport
}


// 6) Program: Resten af systemet kender kun abstraktionen INetworkReport
class Program
{
    static void Main()
    {
        NetworkReportFactory reportFactory = new NetworkReportFactory();
        
        // Dummy data
        var snapshot = new NetworkActivitySnapshot
        {
            ActiveConnections = 124,
            FailedLogins = 17,
            OpenPorts = 42,
            AvgPortLoadPercent = 63.5,
            SuspiciousIps = new List<string> { "192.168.0.13", "10.0.0.77" }
        };

        // Simuler "logged in user role"
        var role = UserRole.Leader;

        // Factory vælger korrekt rapport
        INetworkReport report = reportFactory.Create(role);

        Console.WriteLine(report.Title);
        Console.WriteLine(new string('-', report.Title.Length));
        report.Render(snapshot);

        Console.WriteLine("\nDone.");
    }
}
