using System.Collections.Generic;
using System.Linq;

namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// 
    /// </summary>
    public class Gain : IAudioElement
    {
        private readonly ISet<IAudioElement> _inputs;
        private readonly string _output = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputs"></param>
        public Gain(IEnumerable<IAudioElement> inputs) => _inputs = new HashSet<IAudioElement>(inputs);

        /// <summary>
        /// 
        /// </summary>
        public Gain() : this(new HashSet<IEffect>()) { }
        
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, float> Parameters { get; set; } = new Dictionary<string, float> { { "value", 1.0f } };

        /// <summary>
        /// 
        /// </summary>
        public string Output
        {
            get => _output;
            private set => _output.Append<>($", {value}");
        }

        /// <summary>
        /// 
        /// </summary>
        public int Channels => _inputs.Count;

        /// <summary>
        /// 
        /// </summary>
        public string Name => "Gain";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void AddInput(IAudioElement e)
        {
            _inputs.Add(e);
            Output = e.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void RemoveInput(IAudioElement e) => _inputs.Remove(e);
        
    }
}
