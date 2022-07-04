using System;
using System.Collections.Generic;
using System.Linq;

namespace Resplan.Sirri.ProcessingUnit
{
    public class ProcessingUnit : IProcessingUnit
    {
        /// <summary>
        /// 
        /// </summary>
        public Gain GainIn { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public Gain GainOut { get; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Effect> Effects { get; } = new List<Effect>();

        /// <summary>
        /// 
        /// </summary>
        public ProcessingUnit(IReadOnlyList<Effect> effects)
        {
            GainIn = new Gain();
            GainOut = new Gain();
            for (var i = 0; i < effects.Count; i++)
            {
                AddEffectAtPosition(i, effects[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public void AddInput(Gain g) => GetEffectAtPosition(0).AddInput(g);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public void Connect(Gain g) => g.AddInput(GetEffectAtPosition(Size - 1));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Effect GetEffectAtPosition(int index) => Effects.ElementAt(index);
        
        /// <summary>
        /// 
        /// </summary>
        public int Size => Effects.Count;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="effect"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void AddEffectAtPosition(int index, Effect effect)
        {
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException("Cannot add at this position.");
            }
            Effects.Insert(index, effect);
            if (index != 0) 
            {
                ConnectEffects(GetEffectAtPosition(index - 1), effect);
            } 
            else 
            {
                effect.GainIn.AddInput(GainIn);
            }
            if (index != Size - 1) 
            {
                ConnectEffects(effect, GetEffectAtPosition(index + 1));
            } 
            else 
            {
                GainOut.RemoveAllInputs();
                GainOut.AddInput(effect.GainOut);
            }
        }

        private void ConnectEffects(Effect from, Effect to)
        {
            to.GainIn.RemoveAllInputs();
            to.GainIn.AddInput(from.GainOut);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveEffectAtPosition(int index)
        {
            if (index < 0 && index > Size)
            {
                throw new IndexOutOfRangeException("Cannot remove at this position.");
            }
            if (Size < 1)
            {
                throw new InvalidOperationException("Cannot perform this operation when " +
                                                    "there is only one effect stored.");
            }
            if (index != Size - 1) 
            {
                GetEffectAtPosition(index + 1).RemoveAllInputs(); 
                if (index != 0) 
                {
                    ConnectEffects(GetEffectAtPosition(index - 1), GetEffectAtPosition(index + 1));
                } 
                else 
                {
                    GetEffectAtPosition(1).GainIn.AddInput(GainIn);
                }
            } 
            else 
            {
                GainOut.RemoveAllInputs();
                GainOut.AddInput(GetEffectAtPosition(index - 1).GainOut);
            }
            Effects.RemoveAt(index);
        }
    }
}