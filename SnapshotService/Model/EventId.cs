namespace SnapshotService
{
    public enum EventId
    {
        StartingWindowsService = 1,
        StopingWindowsService = 2,
        ConsoleMode = 3,
        NewClientMessage = 4,
        ClientMessage = 5,
        ErrorTakingSnapshot = 6,
    }
}