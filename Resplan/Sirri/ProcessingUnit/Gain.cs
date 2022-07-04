using System.Collections.Generic;

namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// This class is a mock implementation of a Gain, which is the audio processing tool that regulates the volume
    /// of the input source.
    /// </summary>
    public class Gain : IAudioElement
    {
        private ISet<IAudioElement> _inputs = new HashSet<IAudioElement>();

        /// <summary>
        /// <inheritdoc cref="IAudioElement.Channels"/>
        /// </summary>
        public int Channels { get; }

        /// <summary>
        /// Creates a new gain with the given number of channels.
        /// </summary>
        /// <param name="channels">
        /// The number of inputs and outputs of this gain.
        /// </param>
        public Gain(int channels) => Channels = channels;

        /// <summary>
        /// Creates a new gain with just one input and one output.
        /// </summary>
        public Gain() : this(1) { }
        
        /// <summary>
        /// <inheritdoc cref="IAudioElement.Parameters"/>
        /// </summary>
        public Dictionary<string, float> Parameters { get; set; } = new Dictionary<string, float> { { "value", 1.0f } };

        /// <summary>
        /// <inheritdoc cref="IAudioElement.AddInput"/>
        /// </summary>
        /// <param name="e">
        /// <inheritdoc cref="IAudioElement.AddInput"/>
        /// </param>
        public void AddInput(IAudioElement e)
        {
            _inputs.Add(e);
        }

        /// <summary>
        /// <inheritdoc cref="IAudioElement.RemoveInput"/>
        /// </summary>
        /// <param name="e">
        /// <inheritdoc cref="IAudioElement.RemoveInput"/>
        /// </param>
        public void RemoveInput(IAudioElement e) => _inputs.Remove(e);

        /// <summary>
        /// <inheritdoc cref="IAudioElement.RemoveAllInputs"/>
        /// </summary>
        public void RemoveAllInputs()
        {
            _inputs = new HashSet<IAudioElement>();
        }
    }
}
