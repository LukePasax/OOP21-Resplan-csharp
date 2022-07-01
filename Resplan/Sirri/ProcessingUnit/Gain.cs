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
        public Dictionary<string, float> Parameters { get; set; }

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
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputs"></param>
        public Gain(IEnumerable<IAudioElement> inputs)
        {
            _inputs = new HashSet<IAudioElement>(inputs);
            Parameters = new Dictionary<string, float> { { "value", 1.0f } };
            Name = "Gain";
        }

        /// <summary>
        /// 
        /// </summary>
        public Gain() : this(new HashSet<IEffect>()) { }

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
        public void RemoveInput(IAudioElement e)
        {
            _inputs.Remove(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetOutput()
        {
            return Output;
        }

    }
}
