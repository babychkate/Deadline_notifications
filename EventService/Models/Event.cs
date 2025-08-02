namespace EventService.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ScheduledTime { get; set; }
        public List<Guid> RegisteredUserIds { get; set; } = new();
    }
}
