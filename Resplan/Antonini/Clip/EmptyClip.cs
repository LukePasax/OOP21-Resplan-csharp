using System;

namespace Resplan.Antonini.Clip
{
    public class EmptyClip : IClip<NoContent>
    {
        public string Title { get; private set; }

        private double _duration;
        
        /// <summary>
        /// <inheritdoc cref="IClip{X}.Duration"/>
        /// </summary>
        /// <exception cref="ArgumentException">If the specified duration is zero, a negative value or if the specified duration is bigger than the content duration. </exception>
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

        /// <summary>
        /// <inheritdoc cref="IClip{X}.ContentPosition"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">If this RPClip is Empty.</exception>
        public double ContentPosition
        {
            get => throw new InvalidOperationException("Can't get the Content Position. This is an Empty Clip. " 
                                                       + "Convert the clip into one with content then retry."); 
            set => throw new InvalidOperationException("Can't set Content Position in an Empty Clip. "
                                                       + "Convert the clip into one with content then retry.");
        }
        /// <summary>
        /// <inheritdoc cref="IClip{X}.ContentDuration"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">If this RPClip is Empty.</exception>
        public double ContentDuration => throw new InvalidOperationException("An EmptyClip has no content");

        /// <summary>
        /// Creates an EmptyClip with a duration of <see cref="IClip{X}.DEFAULT_DURATION"/>.
        /// </summary>
        /// <param name="title">The title of the clip.</param>
        public EmptyClip(string title)
        {
            Title = title;
            Duration = IClip<NoContent>.DEFAULT_DURATION;
        }
        
        /// <summary>
        /// Creates an EmptyClip with a specified duration.
        /// </summary>
        /// <param name="title">The title of the clip.</param>
        /// <param name="duration">The duration of this clip in milliseconds.</param>
        public EmptyClip(string title, double duration)
        {
            Title = title;
            Duration = duration;
        }

        /// <summary>
        /// <inheritdoc cref="IClip{X}.IsEmpty"/>
        /// </summary>
        /// <returns> true if and only if the clip has no content;
        /// false otherwise. </returns>
        public bool IsEmpty() => true;

        /// <summary>
        /// <inheritdoc cref="IClip{X}.GetContent"/>
        /// </summary>
        /// <returns>The clip content.</returns>
        /// <exception cref="InvalidOperationException">If this RPClip is Empty</exception>
        public NoContent GetContent() => throw new InvalidOperationException("Can't get the Content of an Empty Clip. "
                                                                             + "Convert the clip into one with content then retry.");
        /// <summary>
        /// <inheritdoc cref="IClip{X}.Duplicate"/>
        /// </summary>
        /// <param name="title">The title of the new clip.</param>
        /// <returns>a duplicate of this clip.</returns>
        public IClip<NoContent> Duplicate(string title)
        {
            return new EmptyClip(Title, Duration);
        }
    }
}