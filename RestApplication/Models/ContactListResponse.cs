namespace RestApplication.Models
{
    public class ContactListResponse
    {
        public int Current_page { get; set; }
        public List<ContactList>? Data { get; set; }
        public string? First_page_url { get; set; }
        public string? From { get; set; }
        public int Last_page { get; set; }
        public string? Last_page_url { get; set; }
        public string? Next_page_url { get; set; }
        public string? Path { get; set; }
        public int Per_page { get; set; }
        public string? Prev_page_url { get; set; }
        public string? To { get; set; }
        public int Total { get; set; }
        public bool Success { get; set; }
    }
}
