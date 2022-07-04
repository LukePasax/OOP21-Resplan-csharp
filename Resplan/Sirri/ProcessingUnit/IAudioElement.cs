using System.Collections.Generic;

namespace Resplan.Sirri.ProcessingUnit
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAudioElement
    {
        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, float> Parameters { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Channels { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        void AddInput(IAudioElement e);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        void RemoveInput(IAudioElement e);

        /// <summary>
        /// 
        /// </summary>
        void RemoveAllInputs();
        
    }
}
