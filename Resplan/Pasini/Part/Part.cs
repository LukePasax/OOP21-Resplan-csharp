namespace Resplan.Pasini.Part
{

    /// <summary>
    /// An abstract implementation of the <see cref="IPart"/> interface.
    /// </summary>
    public abstract class Part : IPart
    {
        private string _description;

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
        public string? Description
        {
            get => _description == "" ? null : _description;
            set => _description = value;
        }

        /// <summary>
        /// Builds a new instance of the <see cref="Part"/> class.
        /// </summary>
        /// <param name="title"> The title of the part </param>
        /// <param name="type"> The type of the part </param>
        /// <param name="description"> The optional description of the part </param>
        protected Part(string title, IPart.PartType type, string description = "")
        {
            Title = title;
            _description = description;
            Type = type;
        }
    }
}