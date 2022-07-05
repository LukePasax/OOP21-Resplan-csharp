using System.Collections.Generic;
using System.Linq;
using Resplan.Antonini.Clip;
using Resplan.Pasini.Part;

namespace Resplan.Pasini.Linker
{
    public class ClipLinker<T> : IClipLinker<T> where T : IContent
    {
        private readonly Dictionary<IPart, IClip<T>> _clips;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ClipLinker{T}"/> class.
        /// </summary>
        public ClipLinker()
        {
            _clips = new Dictionary<IPart, IClip<T>>();
        }
        
        /// <summary>
        /// <inheritdoc cref="IClipLinker{T}.addClipReferences"/>
        /// </summary>
        public void addClipReferences(IClip<T> clip, IPart part)
        {
            _clips.Add(part, clip);
        }

        /// <summary>
        /// <inheritdoc cref="IClipLinker{T}.getClipFromPart"/>
        /// </summary>
        public IClip<T> getClipFromPart(IPart part)
        {
            return _clips[part];
        }

        /// <summary>
        /// <inheritdoc cref="IClipLinker{T}.getPartFromClip"/>
        /// </summary>
        public IPart getPartFromClip(IClip<T> clip)
        {
            return _clips.FirstOrDefault(x => x.Value.Equals(clip)).Key;
        }

        /// <summary>
        /// <inheritdoc cref="IClipLinker{T}.getPart"/>
        /// </summary>
        public IPart getPart(string title)
        {
            return _clips.FirstOrDefault(x => x.Value.Title.Equals(title)).Key;
        }

        /// <summary>
        /// <inheritdoc cref="IClipLinker{T}.clipExists"/>
        /// </summary>
        public bool clipExists(string title)
        {
            return _clips.Any(x => x.Value.Title.Equals(title));
        }

        /// <summary>
        /// <inheritdoc cref="IClipLinker{T}.removeClip"/>
        /// </summary>
        public void removeClip(IPart part)
        {
            _clips.Remove(part);
        }
    }
}