classDiagram
    direction LR

    class NetworkReportFactory {
        - _report : INetworkReport
        + NetworkReportFactory() 
        + Create(role : UserRole) INetworkReport
    }

    class UserRole {
        <<enumeration>>
        ItManager
        Leader
        SecuritySpecialist
        ItSupport
    }

    class INetworkReport {
        <<interface>>
        + Title : string
        + Render(snapshot : NetworkActivitySnapshot) void
    }

    class NetworkActivitySnapshot {
        + ActiveConnections : int
        + FailedLogins : int
        + OpenPorts : int
        + AvgPortLoadPercent : double
        + SuspiciousIps : List~string~
    }

    class ItManagerReport {
        + Title : string
        + Render(snapshot : NetworkActivitySnapshot) void
    }

    class LeaderReport {
        + Title : string
        + Render(snapshot : NetworkActivitySnapshot) void
    }

    class SecuritySpecialistReport {
        + Title : string
        + Render(snapshot : NetworkActivitySnapshot) void
    }

    class ItSupportReport {
        + Title : string
        + Render(snapshot : NetworkActivitySnapshot) void
    }

    %% Factory depends on role + returns abstraction
    NetworkReportFactory ..> UserRole : selects
    NetworkReportFactory ..> INetworkReport : creates

    %% Concrete reports realize the interface
    ItManagerReport ..|> INetworkReport
    LeaderReport ..|> INetworkReport
    SecuritySpecialistReport ..|> INetworkReport
    ItSupportReport ..|> INetworkReport

    %% Reports use snapshot data
    INetworkReport ..> NetworkActivitySnapshot : reads