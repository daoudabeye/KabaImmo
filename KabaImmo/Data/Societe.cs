using Microsoft.Extensions.Hosting;

namespace KabaImmo.Data
{
    public class Societe
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string TVA { get; set; }
        public string RCS { get; set; }
        public decimal Capital { get; set; }
        public string Domaine { get; set; }
        public string Logo { get; set; }
        public string Signature { get; set; }
        public ICollection<Contact> Contacts { get; } = new List<Contact>();
        public ICollection<Adresse> Adresses { get; set; }
        public ICollection<PieceIdentite> PieceIdentite { get; set; }
        public ICollection<Banque> Banques { get; set; }
        public ICollection<Immeuble> Immeuble { get; set; }
    }
}
