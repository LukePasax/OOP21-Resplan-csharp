namespace Resplan.Pasini.Part
{

	/// <summary>
	/// It's an interface that represents a generic element of high level DAW.
	/// </summary>
	public interface IElement
	{
		/// <summary>
		/// Represents the title of the element.
		/// </summary>
		string Title { get; }
		
		/// <summary>
		/// Represents the description of the element.
		/// </summary>
		string? Description { get; set; }
	}
}