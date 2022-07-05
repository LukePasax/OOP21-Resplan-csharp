namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An abstract implementation of the <see cref="IPart"/> interface.
    /// </summary>
    public abstract class AbstractPart : IPart
    {

        /// <summary>
        /// <inheritdoc cref="IElement.Title"/>
        /// </summary>
        public string Title { get; }
        
        /// <summary>
        /// <ineritdoc cref="IPart.Type"/>
        /// </summary>
        public IPart.PartType Type { get; }

        /// <summary>
        /// <inheritdoc cref="IElement.Description"/>
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Builds a new instance of the <see cref="AbstractPart"/> class.
        /// </summary>
        /// <param name="title"> The title of the part </param>
        /// <param name="type"> The type of the part </param>
        /// <param name="description"> The optional description of the part </param>
        protected AbstractPart(string title, IPart.PartType type, string? description = null)
        {
            Title = title;
            Description = description;
            Type = type;
        }
        
        protected bool Equals(AbstractPart other)
        {
            return Title == other.Title;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((AbstractPart)obj);
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}