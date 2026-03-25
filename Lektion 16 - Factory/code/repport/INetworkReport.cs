 // 1) Fælles abstraktion: "rapport/visning"
public interface INetworkReport
{
    string Title { get; }
    void Render(NetworkActivitySnapshot snapshot);
}