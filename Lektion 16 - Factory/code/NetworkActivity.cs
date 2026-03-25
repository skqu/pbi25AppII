
// 2) Data input til rapporter (dummy-model, kan udvides)
public class NetworkActivitySnapshot
{
    public int ActiveConnections { get; set; }
    public int FailedLogins { get; set; }
    public int OpenPorts { get; set; }
    public double AvgPortLoadPercent { get; set; }
    public List<string> SuspiciousIps { get; set; } = new();
}