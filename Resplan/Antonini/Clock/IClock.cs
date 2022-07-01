namespace Resplan.Antonini.Clock
{
    public interface IClock
    {
        long Step { get; }

        double Time { get; set; }
        
        void DoStep();
        
        void Reset();
    }
}