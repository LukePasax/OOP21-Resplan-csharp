using System;

namespace Resplan.Antonini.Clip
{
    public class NoContent : IContent 
    {
        public override string ToString()
        {
            return "This object represents an empty content for an RPClip";
        }
    }
}