namespace ServerContactForm
{
    /*public class ContactData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public ICollection<MessagesData> Messages { get; set; }
        public ICollection<ThemesMessagesData> ThemesMessages { get; set; }
    }*/
    public class ContactData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public ICollection<MessagesData> Messages { get; set; }
    }
}
