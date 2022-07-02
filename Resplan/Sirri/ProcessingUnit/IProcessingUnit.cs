using System.Collections.Generic;

namespace Resplan.Sirri.ProcessingUnit
{
    public interface IProcessingUnit
    {
        public IList<IEffect> Effects { get; }
        
        public void AddInput(Gain g);

        public void Connect(Gain g);

        public IEffect GetEffectAtPosition(int index);
        
        public int Size { get; }

        public void AddEffectAtPosition(int index, IEffect effect);

        public void RemoveEffectAtPosition(int index);
        
    }
}