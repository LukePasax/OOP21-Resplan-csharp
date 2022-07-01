using System.Collections.Generic;
using System.Linq;

namespace Resplan.Sirri
{
    public class Gain
    {
        private readonly Stack<IEffect> _inputs;
        private string _output;
        
        public string Output
        {
            get => _output;
            private set => _output.Append<>($", {value}");
        }

        public Gain(IEnumerable<IEffect> inputs)
        {
            _inputs = new Stack<IEffect>(inputs);
        }

        public Gain()
        {
            _inputs = new Stack<IEffect>();
        }

        public void AddInput(IEffect e)
        {
            _inputs.Push(e);
            Output = e.Name;
        }

        public void RemoveInput(IEffect e)
        {
            _inputs.Pop();
        }
    }
    
}