using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp2
{
    public class ADVNeuron
    {
        private decimal weight = 0.5m;

        public decimal LastError { get; private set; }

        public decimal Smoothing { get; set; } = 0.000001m;

        public decimal ProcessInput(object input)
        {
            return (decimal)input * weight;
        }

        public decimal RestoreiInput(decimal output)
        {
            return output / weight;
        }

        public void SetWeight(object input, object result)
        {
            var currentRes = (decimal)input * (decimal)weight;

            LastError = (decimal)result - currentRes;

            var correction = (LastError / currentRes) * Smoothing;

            weight += correction;
        }
    }
}
