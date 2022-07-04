using System.Collections.Generic;

namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// Interface that models an element that can be used to connect audio sources. Specifically, an implementation
    ///of this interface must have one input and one output <see cref="Gain"/>. It is important to underline the fact
    /// that an audio element does not necessarily have to process audio, as it may just connect two other audio element
    /// or sources. Still, the interface has methods specifically thought to set and obtain the element parameters'
    /// values. This does mean that any audio effect implementation can be a subclass of this interface.
    /// The difference in how the sound is manipulated by the effect is going to be reflected by its parameters.
    /// </summary>
    public interface IAudioElement
    {
        /// <summary>
        /// Parameters change how the element processes the sound. Parameters depend on the element.
        /// </summary>
        Dictionary<string, float> Parameters { get; set; }

        /// <summary>
        /// The number of input and output channels of the element.
        /// </summary>
        int Channels { get; }
        
        /// <summary>
        /// Adds the given source to the inputs of the channel.
        /// </summary>
        /// <param name="e">
        /// The audio element that has to be added to the inputs.
        /// </param>
        void AddInput(IAudioElement e);

        /// <summary>
        /// Removes the given source from the inputs of the channel.
        /// </summary>
        /// <param name="e">
        /// The audio element that has to be removed from the inputs.
        /// </param>
        void RemoveInput(IAudioElement e);

        /// <summary>
        /// Removes all the connections that this effect has with other elements.
        /// </summary>
        void RemoveAllInputs();
    }
}
