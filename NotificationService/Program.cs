using NotificationService.Services;

class Program
{
    static void Main(string[] args)
    {
        var listener = new EventListener();
        listener.Start();
    }
}
