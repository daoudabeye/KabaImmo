namespace KabaImmo.Data
{
    public class Societe
    {
        public string Nom { get; set; }
        public string TVA { get; set; }
        public string RCS { get; set; }
        public decimal Capital { get; set; }
        public string DomaineActivite { get; set; }
        public Adresse Adresse { get; set; }

    }
}
