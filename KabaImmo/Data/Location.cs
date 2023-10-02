namespace KabaImmo.Data
{
    public enum TypeBail
    {
        HABITATION,
        HABITATION_MEUBLE,
        COMMERCIALE,
        PROFESSIONNEL,
        DOMICILIATION,
        SAISONIERE,
        MIXTE
    }

    public enum Utilisation
    {
        RESIDENCE_PRINCIPAL,
        RESIDENCE_SECONDAIRE,
        PROFESSIONNEL
    }

    public enum MethodePaiement
    {
        JOURNALIER,
        MENSUEL,
        BIMESTRIEL,
        TRIMESTRIEL,
        QUADRIMESTRIEL,
        SEMESTRIEL,
        ANNUEL,
        FORFAITAIRE
    }

    public enum MoyenPaiement
    {
        CarteCredit,
        Cheque,
        Especes,
        Prelevement,
        Virement
    }

    public class Location
	{
        public Guid Id { get; set; }
        public Appartement Appartement { get; set; }
        public TypeBail TypeBail { get; set; }
        public string Nom { get; set; }
        public Utilisation Utilisation { get; set; }
        public DateOnly DateDebut { get; set; }
        public DateOnly FinBail { get; set; }
        public bool Renouvellement { get; set; }
        public MoyenPaiement MoyenPaiement { get; set; }
        public int DatePaiement { get; set; }
        public decimal LoyerHorsCharges {  get; set; }
        public decimal Charges {  get; set; }
        public Locataire locataire { get; set; }
    }
}
