namespace Resplan.Sirri.ProcessingUnit
{
    public interface IEffect : IAudioElement
    {
        string Name { get; }
        
        Gain GainIn { get; }
        
        Gain GainOut { get; }
        
    }
}
