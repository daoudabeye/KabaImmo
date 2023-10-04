namespace KabaImmo.Data
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string EmailSecondaire { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }
        public Societe Societe { get; set; } = null;
        public Immeuble Immeuble { get; set; } = null;
    }
}
