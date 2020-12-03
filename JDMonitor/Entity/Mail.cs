namespace JDMonitor.Entity
{
    public class Mail: EntityBase
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool Success { get; set; }

        public int RecordId { get; set; }
    }
}
