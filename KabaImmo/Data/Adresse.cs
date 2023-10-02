namespace KabaImmo.Data
{
	public enum TypeAdresse
	{
		PERSONNELLE=1,
		PROFESSIONNELLE=2,
		SOCIETE=3,
		BANQUE=4
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
	}

	public class CoordonneesBancaire
	{
		public Guid Id { get; set; }
        public string Iban { get; set; }
        public string Swift { get; set; }
		public Adresse Adresse {  get; set; }
    }
}
