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
        public IList<AbstractEffect> Effects { get; } = new List<AbstractEffect>();

        /// <summary>
        /// 
        /// </summary>
        public ProcessingUnit(IReadOnlyList<AbstractEffect> effects)
        {
            GainIn = new Gain();
            GainOut = new Gain();
            if (effects.Count == 0)
            {
                throw new ArgumentException("Cannot create an empty processing unit.");
            }
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
        public AbstractEffect GetEffectAtPosition(int index) => Effects.ElementAt(index);
        
        /// <summary>
        /// 
        /// </summary>
        public int Size => Effects.Count;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="abstractEffect"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void AddEffectAtPosition(int index, AbstractEffect abstractEffect)
        {
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException("Cannot add at this position.");
            }
            Effects.Insert(index, abstractEffect);
            if (index != 0) 
            {
                ConnectEffects(GetEffectAtPosition(index - 1), abstractEffect);
            } 
            else 
            {
                abstractEffect.GainIn.AddInput(GainIn);
            }
            if (index != Size - 1) 
            {
                ConnectEffects(abstractEffect, GetEffectAtPosition(index + 1));
            } 
            else 
            {
                GainOut.RemoveAllInputs();
                GainOut.AddInput(abstractEffect.GainOut);
            }
        }

        private void ConnectEffects(AbstractEffect from, AbstractEffect to)
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
            if (index < 0 || index > Size)
            {
                throw new IndexOutOfRangeException("Cannot remove at this position.");
            }
            if (Size <= 1)
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