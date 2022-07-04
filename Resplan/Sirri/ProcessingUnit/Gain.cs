using System.Collections.Generic;
using System.Linq;

namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// 
    /// </summary>
    public class Gain : IAudioElement
    {
        public ISet<IAudioElement> _inputs = new HashSet<IAudioElement>();

        /// <summary>
        /// 
        /// </summary>
        public int Channels { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channels"></param>
        public Gain(int channels) => Channels = channels;

        /// <summary>
        /// 
        /// </summary>
        public Gain() : this(1) { }
        
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, float> Parameters { get; set; } = new Dictionary<string, float> { { "value", 1.0f } };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void AddInput(IAudioElement e)
        {
            _inputs.Add(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void RemoveInput(IAudioElement e) => _inputs.Remove(e);

        /// <summary>
        /// 
        /// </summary>
        public void RemoveAllInputs()
        {
            _inputs = new HashSet<IAudioElement>();
        }
    }
}
