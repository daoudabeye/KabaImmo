namespace KabaImmo.Data
{
    public enum Civilite
    {
        MLLE = 1,
        MDME = 2,
        M = 3,
        M_ET_MDME = 4
    }

    public enum TypeProprietaire
    {
        PARTICULIER = 1,
        SOCIETE = 2,
        AGENCE= 3,
    }

    public class Utilisateur
    {
        public Guid Id { get; set; }
        public bool Invitation { get; set; } = false;
        public TypeProprietaire TypeLocataire { get; set; }
        public string Photo { get; set; }
        public string Couleur { get; set; }
        public Civilite Civilite { get; set; }
        public string Designation { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateOnly DateNaissance { get; set; }
        public DateOnly LieuNaissance { get; set; }
        public string NumeroCarteIdentite { get; set; }
        public string Profession { get; set; }
        public decimal RevenusMensuel { get; set; }
        public Contact Contact { get; set; }
        public Adresse Adresse { get; set; }
        public PieceIdentite PieceIdentite { get; set; }
    }

    public class Garant
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public PieceIdentite PieceIdentite { get; set; }
        public Adresse Adresse { get; set; }

        public TypeProprietaire TypeGarant { get; set; }

    }
}
