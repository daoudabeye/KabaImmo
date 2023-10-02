namespace KabaImmo.Data
{
	public class Appartement
	{
		public Guid Id { get; set; }
		public string Nom { get; set; }
		public string Description { get; set; }
		public string Type { get; set; }
		public string Couleur { get; set; }
		public string TypeLocation { get; set; }
		public decimal LoyerHorsCharges { get; set; }
		public decimal Charges { get; set; }
		public int Superficie { get; set; }
		public int Pieces { get; set; }
		public int SaleDeBain { get; set; }
		public DateOnly DateContruction { get; set; }
		public string note { get; set; }

		public Immeuble Immeuble { get; set; }

	}


}
