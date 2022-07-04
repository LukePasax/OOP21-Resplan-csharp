﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// This class represents a basic implementation of <see cref="IProcessingUnit"/>.
    /// </summary>
    public class ProcessingUnit : IProcessingUnit
    {
        /// <summary>
        /// <inheritdoc cref="IProcessingUnit.GainIn"/>
        /// </summary>
        public Gain GainIn { get; }
        
        /// <summary>
        /// <inheritdoc cref="IProcessingUnit.GainOut"/>
        /// </summary>
        public Gain GainOut { get; }

        /// <summary>
        /// <inheritdoc cref="IProcessingUnit.Effects"/>
        /// </summary>
        public IList<AbstractEffect> Effects { get; } = new List<AbstractEffect>();

        /// <summary>
        /// Creates a processing unit with the given list of effects.
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
        /// <inheritdoc cref="IProcessingUnit.AddInput"/>
        /// </summary>
        /// <param name="g">
        /// <inheritdoc cref="IProcessingUnit.AddInput"/>
        /// </param>
        public void AddInput(Gain g) => GetEffectAtPosition(0).AddInput(g);

        /// <summary>
        /// <inheritdoc cref="IProcessingUnit.Connect"/>
        /// </summary>
        /// <param name="g">
        /// <inheritdoc cref="IProcessingUnit.Connect"/>
        /// </param>
        public void Connect(Gain g) => g.AddInput(GetEffectAtPosition(Size - 1));

        /// <summary>
        /// <inheritdoc cref="IProcessingUnit.GetEffectAtPosition"/>
        /// </summary>
        /// <param name="index">
        /// <inheritdoc cref="IProcessingUnit.GetEffectAtPosition"/>
        /// </param>
        /// <returns>
        /// <inheritdoc cref="IProcessingUnit.GetEffectAtPosition"/>
        /// </returns>
        public AbstractEffect GetEffectAtPosition(int index) => Effects.ElementAt(index);
        
        /// <summary>
        /// <inheritdoc cref="IProcessingUnit.Size"/>
        /// </summary>
        public int Size => Effects.Count;
        
        /// <summary>
        /// <inheritdoc cref="IProcessingUnit.AddEffectAtPosition"/>
        /// </summary>
        /// <param name="index">
        /// <inheritdoc cref="IProcessingUnit.AddEffectAtPosition"/>
        /// </param>
        /// <param name="abstractEffect">
        /// <inheritdoc cref="IProcessingUnit.AddEffectAtPosition"/>  
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// If the given index is out of bounds.
        /// </exception>
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
        /// <inheritdoc cref="IProcessingUnit.RemoveEffectAtPosition"/>
        /// </summary>
        /// <param name="index">
        /// <inheritdoc cref="IProcessingUnit.RemoveEffectAtPosition"/>
        /// </param>
        /// <exception cref="IndexOutOfRangeException">
        /// If the given index is out of bounds.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// If there is only one <see cref="AbstractEffect"/> stored when this method is called.
        /// </exception>
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