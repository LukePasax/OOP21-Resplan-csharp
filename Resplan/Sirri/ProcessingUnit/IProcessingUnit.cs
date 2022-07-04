using System.Collections.Generic;

namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// Manages the sequence of effects that manipulate an audio source.
    /// A ProcessingUnit instantiation must always contain at least one effect.
    /// It is important to note that the order the effects are stored by is relevant to the processing
    /// and ultimately to the output of the unit.
    /// </summary>
    public interface IProcessingUnit
    {
        /// <summary>
        /// Gets the <see cref="Gain"/> through which audio comes in.
        /// </summary>
        public Gain GainIn { get; }
        
        /// <summary>
        /// Gets the <see cref="Gain"/> through which audio comes out.
        /// </summary>
        public Gain GainOut { get; }
        
        /// <summary>
        /// Gets the sequence of effects currently stored in the processing unit.
        /// </summary>
        public IList<AbstractEffect> Effects { get; }
        
        /// <summary>
        /// Adds the audio signal that needs to be processed.
        /// </summary>
        /// <param name="g">
        /// the <see cref="Gain"/> that represents the audio source.
        /// </param>
        public void AddInput(Gain g);

        /// <summary>
        /// Allows the client to receive the output of the whole processing.
        /// </summary>
        /// <param name="g">
        /// The <see cref="Gain"/> to which the output must be connected to.
        /// </param>
        public void Connect(Gain g);

        /// <summary>
        /// Allows finding which effect is stored at the given position of the sequence.
        /// </summary>
        /// <param name="index">
        /// A position in the sequence.
        /// </param>
        /// <returns>
        /// the <see cref="AbstractEffect"/> that is placed at the given position.
        /// </returns>
        public AbstractEffect GetEffectAtPosition(int index);
        
        /// <summary>
        /// Gets the amount of <see cref="AbstractEffect"/>s currently stored in the processing unit.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// Adds a new effect in the given position of the sequence. If the position is the first out-of-bound
        /// index to the right this method has the exact same behavior of the addEffect method.
        /// For example, this occurs when the sequence's last element is at index 3 and the given position is index 4.
        /// Note that this method also match the preceding effect output (if present) to the given effect input
        /// and the output of the latter to the following effect input (if present).
        /// The same policies of the addEffect method are used when the number of inputs and outputs of
        /// two consecutive <see cref="AbstractEffect"/> is different.
        /// </summary>
        /// <param name="index">
        /// A position in the sequence.
        /// </param>
        /// <param name="effect">
        /// The <see cref="AbstractEffect"/> that represents the effect to be added.
        /// </param>
        public void AddEffectAtPosition(int index, AbstractEffect effect);

        /// <summary>
        /// Removes the effect at the given position from the sequence.
        /// </summary>
        /// <param name="index">
        /// A position in the sequence.
        /// </param>
        public void RemoveEffectAtPosition(int index);
    }
}