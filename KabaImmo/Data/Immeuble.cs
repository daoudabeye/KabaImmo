namespace KabaImmo.Data
{
	public class Immeuble
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
        public Adresse Adresse { get; set; }
        public int Superficie { get; set; }
		public string Note { get; set; }

    }
}
