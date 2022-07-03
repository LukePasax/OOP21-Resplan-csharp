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
        
        public IList<Effect> Effects { get; }
        
        public void AddInput(Gain g);

        public void Connect(Gain g);

        public Effect GetEffectAtPosition(int index);
        
        public int Size { get; }

        public void AddEffectAtPosition(int index, Effect effect);

        public void RemoveEffectAtPosition(int index);
        
    }
}