using System;

namespace Resplan.Antonini.Clip
{
    public class EmptyClip : IClip<NoContent>
    {
        public string Title { get; private set; }

        private double _duration;
        public double Duration
        {
            get => _duration;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The duration of a clip must be a non-zero and positive value.");
                }
                else
                {
                    _duration = value;
                }
            }
        }

        public double ContentPosition
        {
            get => throw new InvalidOperationException("Can't get the Content Position. This is an Empty Clip. " 
                                                       + "Convert the clip into one with content then retry."); 
            set => throw new InvalidOperationException("Can't set Content Position in an Empty Clip. "
                                                       + "Convert the clip into one with content then retry.");
        }
        public double ContentDuration => throw new InvalidOperationException("An EmptyClip has no content");

        public EmptyClip(string title)
        {
            Title = title;
            Duration = IClip<NoContent>.DEFAULT_DURATION;
        }
        
        public EmptyClip(string title, double duration)
        {
            Title = title;
            Duration = duration;
        }

        public bool IsEmpty() => true;

        public NoContent GetContent() => throw new InvalidOperationException("Can't get the Content of an Empty Clip. "
                                                                             + "Convert the clip into one with content then retry.");

        public IClip<NoContent> Duplicate(string title)
        {
            return new EmptyClip(Title, Duration);
        }
    }
}