using Resplan.Antonini.Clip;
using Resplan.Pasini.Part;

namespace Resplan.Pasini.Linker
{
    /// <summary>
    /// This interface represents a class to link a <see cref="IPart"/> to its corresponding <see cref="IClip{X}"/>.
    /// </summary>
    /// <typeparam name="T"> The content type of the <see cref="IClip{X}"/>, must implement ...</typeparam>
    public interface IClipLinker<T> where T : IContent
    {
        
        /// <summary>
        /// This method links the given <see cref="IPart"/> to the given <see cref="IClip{X}"/>.
        /// </summary>
        /// <param name="clip"> the <see cref="IClip{X}"/> to link </param>
        /// <param name="part"> the <see cref="IPart"/> to link </param>
        void addClipReferences(IClip<T> clip, IPart part);
        
        /// <summary>
        /// A method that returns the <see cref="IClip{X}"/> linked to the given <see cref="IPart"/>.
        /// </summary>
        /// <param name="part"> the <see cref="IPart"/> linked </param>
        /// <returns> the <see cref="IClip{X}"/> linked </returns>
        IClip<T> getClipFromPart(IPart part);
        
        /// <summary>
        /// </summary>
        /// <param name="clip"> the <see cref="IClip{X}"/> linked </param>
        /// <returns> the <see cref="IPart"/> </returns>
        IPart getPartFromClip(IClip<T> clip);
        
        /// <summary>
        /// A method that returns the <see cref="IPart"/> with the given title.
        /// </summary>
        /// <param name="title"> the title of the <see cref="IPart"/> </param>
        /// <returns> the <see cref="IPart"/> with the given title </returns>
        IPart getPart(string title);
        
        /// <summary>
        /// This method is used to check if a Clip with the given title exists.
        /// </summary>
        /// <param name="title"> the title of the Clip that need to be checked </param>
        /// <returns> true if the Clip exists, false otherwise </returns>
        bool clipExists(string title);
        
        /// <summary>
        /// This method removes the Clip with the given <see cref="IPart"/>.
        /// </summary>
        /// <param name="part"> the <see cref="IPart"/> of the Clip </param>
        void removeClip(IPart part);
    }
}