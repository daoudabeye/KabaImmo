using System.ComponentModel;

namespace KabaImmo.Data
{
    public enum TypeHabitat
    {
        COLLECTIF,
        INDIVIDUEL
    }

    public enum RegimeJuridique
    {
        COPROPRIETE,
        MONO
    }

    public class Equipements
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public bool Service { get; set; }
        public Lot Lot { get; set; }
        public Immeuble Immeuble { get; set; }
    }

    public enum TypeLot
    {
        [Description("Appartement")]
        APPARTEMENTS,
        [Description("Atelier")]
        ATELIER,
        [Description("Boutique")]
        BOUTIQUE,
        [Description("Box de stockage")]
        BOX_STOCKAGE,
        [Description("Bureau Partagé")]
        BUREAU_PARTAGE,
        [Description("Bureau")]
        BUREAU,
        [Description("Chambre")]
        CHAMBRE,
        [Description("Chateau")]
        CHATEAU,
        [Description("Hôtel")]
        HOTEL,
        [Description("Maison")]
        MAISON,
        [Description("Studio")]
        STUDIO,
        [Description("Terrain")]
        TERRAIN,
        [Description("Villa")]
        VILLA,

    }

    public class Lot
    {
        public Guid Id { get; set; }
        [Description("Saisir un identifiant, référence ou numéro unique.")]
        public string Nom { get; set; }
        [Description("Description du lot")]
        public string Description { get; set; }
        [Description("Type de lot")]
        public TypeLot TypeLot { get; set; }
        [Description("Type Habitat")]
        public TypeHabitat TypeHabitat { get; set;}
        [Description("Couleur")]
        public string Couleur { get; set; }
        [Description("Saisir un identifiant, référence ou numéro unique.")]
        public TypeLocation TypeLocation { get; set; }
        [Description("Loyer Hors Charges")]
        public decimal LoyerHorsCharges { get; set; }
        public decimal Charges { get; set; }
        public int Superficie { get; set; }
        public int Pieces { get; set; }
        public int SaleDeBain { get; set; }
        public DateOnly DateContruction { get; set; }
        public string note { get; set; }
        public bool Meubler { get; set; }
        public bool Fumeur { get; set; }
        public bool Animaux { get; set; }
        public string Parking { get; set; }
        public string Dependances { get; set; }
        public Immeuble Immeuble { get; set; }
        public ICollection<Equipements> Equipements { get; set; }

    }

}
