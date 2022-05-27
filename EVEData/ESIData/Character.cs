using System;
namespace EVEData.ESIData
{
	/// <summary>
    /// 
    /// </summary>
	public class Character
	{
		public long id { get; set; }
		public string? name { get; set; }
	}

	/// <summary>
    /// 
    /// </summary>
	public partial class CharacterIdData
	{
		public Character[]? Characters { get; set; }
	}
}

