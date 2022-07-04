using System.Collections.Generic;

namespace Resplan.Sirri.ProcessingUnit
{
    public interface IProcessingUnit
    {
        /// <summary>
        /// 
        /// </summary>
        public Gain GainIn { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public Gain GainOut { get; }
        
        public IList<AbstractEffect> Effects { get; }
        
        public void AddInput(Gain g);

        public void Connect(Gain g);

        public AbstractEffect GetEffectAtPosition(int index);
        
        public int Size { get; }

        public void AddEffectAtPosition(int index, AbstractEffect abstractEffect);

        public void RemoveEffectAtPosition(int index);
        
    }
}