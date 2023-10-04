namespace KabaImmo.Data
{
    public enum TypeAdresse
    {
        PERSONNELLE = 1,
        PROFESSIONNELLE = 2,
        SOCIETE = 3,
        BANQUE = 4,
        Agence = 5,
    }
    public class Adresse
    {
        public Guid Id { get; set; }
        public TypeAdresse TypeAdresse { get; set; }
        public string Employeur { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public string Batiment { get; set; }
        public string Escalier { get; set; }
        public string Etage { get; set; }
        public string Numero { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string Pays { get; set; }

        public Societe Societe { get; set; } = null;
        public Immeuble Immeuble { get; set; } = null;
        public Banque Banque { get; set; }
    }

    public class Banque
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Iban { get; set; }
        public string Swift { get; set; }
        public string NumeroCompte { get; set; }
        public string CodeBanque { get; set; }
        public string CodeGuichet { get; set; }
        public string CleRib { get; set; }
        public Adresse Adresse { get; set; }
        public Societe Societe { get; set; } = null;

    }
}
