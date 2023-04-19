namespace ServerContactForm
{
    public class ThemesMessagesData
    {
        public int Id { get; set; }
        public string Theme { get; set; } = string.Empty;
        public ICollection<MessagesData> Messages { get; set; }
    }
}
