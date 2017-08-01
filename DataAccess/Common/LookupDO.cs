namespace DataAccess.Common
{
	/// <summary>
	/// Lookup DataObject used to create Lookup Lists
	/// </summary>
    public class LookupDO
    {
		public int  Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }
}
