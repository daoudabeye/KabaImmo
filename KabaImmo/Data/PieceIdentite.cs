namespace KabaImmo.Data
{
    public enum TypePiece
    {
        CARTE_IDENTITE = 1,
        PASSPORT = 2,
        PERMIS = 3,
        CARTE_SEJOUR = 4
    }
    public class PieceIdentite
    {
        public Guid Id { get; set; }
        public PieceIdentite TypePicesIdentite { get; set; }
        public DateOnly Expiration { get; set; }
        public string CopyPiece { get; set; }

        public Societe Societe { get; set; } = null;
    }
}
