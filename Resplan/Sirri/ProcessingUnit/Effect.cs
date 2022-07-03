using System.Collections.Generic;

namespace Resplan.Sirri.ProcessingUnit
{
    public abstract class Effect : IAudioElement
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
        public Dictionary<string, float> Parameters { get; set; } = new Dictionary<string, float>();
        
        /// <summary>
        /// 
        /// </summary>
        public string Output { get; } = string.Empty;
        
        /// <summary>
        /// 
        /// </summary>
        public int Channels { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channels"></param>
        /// <param name="name"></param>
        protected Effect(int channels, string name)
        {
            Channels = channels;
            GainIn = new Gain(channels);
            GainOut = new Gain(channels);
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void AddInput(IAudioElement e) => GainIn.AddInput(e); 
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void RemoveInput(IAudioElement e) => GainIn.RemoveInput(e);

        /// <summary>
        /// 
        /// </summary>
        public void RemoveAllInputs() => GainIn.RemoveAllInputs();

        /// <summary>
        /// 
        /// </summary>
        protected abstract void CalculateOutput();
        
    }
}
