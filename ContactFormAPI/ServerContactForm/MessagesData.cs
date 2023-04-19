namespace ServerContactForm
{
    public class MessagesData
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int ContactDataId { get; set; }
        public int ThemesMessagesDataId { get; set; }
    }
}
