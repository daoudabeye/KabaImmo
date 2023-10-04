namespace KabaImmo.Data
{
    public class Immeuble
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Superficie { get; set; }
        public string Note { get; set; }
        public Adresse Adresse { get; set; } = null;
        public Societe Societe { get; set; } = null;
        public ICollection<Contact> Contacts { get; set; } = null;
        public ICollection<Lot> Lot { get; set; } = null;
        public ICollection<Equipements> Equipements { get; set; }
    }
}
