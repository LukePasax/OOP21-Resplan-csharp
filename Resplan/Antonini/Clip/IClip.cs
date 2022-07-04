namespace Resplan.Antonini.Clip
{
    public interface IClip<X>
    {
       public const double DEFAULT_DURATION = 5000;
        
        string Title { get; }

        double Duration { get; set; }
        
        double ContentPosition { get; set; }
        
        double ContentDuration { get; }
        
        bool IsEmpty();
        
        X GetContent();

        IClip<X> Duplicate(string title);
    }
}