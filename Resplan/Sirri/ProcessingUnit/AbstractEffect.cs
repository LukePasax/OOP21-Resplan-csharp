using System.Collections.Generic;

namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// In the context of this software, this class is the one all effects must extend.
    /// </summary>
    public abstract class AbstractEffect : IAudioElement
    {
        /// <summary>
        /// The <see cref="Gain"/> through which comes the input data.
        /// </summary>
        public Gain GainIn { get; }
        
        /// <summary>
        /// The <see cref="Gain"/> through which goes the output data.
        /// </summary>
        public Gain GainOut { get; }

        /// <summary>
        /// Parameters change how the effect processes the sound. Parameters depend on the effect.
        /// </summary>
        public Dictionary<string, float> Parameters { get; set; } = new Dictionary<string, float>();

        /// <summary>
        /// The number of input and output channels of the effect.
        /// </summary>
        public int Channels { get; }
        
        /// <summary>
        /// The name of the effect in the context of this software.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Base constructor for all the effects of this software.
        /// </summary>
        /// <param name="channels">
        /// The number of input and output channels of the effect.
        /// </param>
        /// <param name="name">
        /// The name of the effect in the context of this software.
        /// </param>
        protected AbstractEffect(int channels, string name)
        {
            Channels = channels;
            GainIn = new Gain(channels);
            GainOut = new Gain(channels);
            Name = name;
        }

        /// <summary>
        /// <inheritdoc cref="IAudioElement.AddInput"/>
        /// </summary>
        /// <param name="e">
        /// <inheritdoc cref="IAudioElement.AddInput"/>
        /// </param>
        public void AddInput(IAudioElement e) => GainIn.AddInput(e); 
        
        /// <summary>
        /// <inheritdoc cref="IAudioElement.RemoveInput"/>
        /// </summary>
        /// <param name="e">
        /// <inheritdoc cref="IAudioElement.RemoveInput"/>
        /// </param>
        public void RemoveInput(IAudioElement e) => GainIn.RemoveInput(e);

        /// <summary>
        /// Removes all the connections that this effect has with other elements.
        /// </summary>
        public void RemoveAllInputs() => GainIn.RemoveAllInputs();
    }
}
