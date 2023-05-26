namespace pp2
{
    public class SingleNeuron
    {
        public class Neuron
        {
            private decimal weight = 0.5m;

            public decimal LastError { get; private set; }

            public decimal Smoothing { get; set; } = 0.000001m; 

            public decimal ProcessInput(decimal input)
            {
                return input * weight;
            }

            public decimal RestoreiInput(decimal output) 
            {
                return output / weight;
            }

            public void SetWeight(decimal input, decimal result)
            {
                var currentRes = input * weight;

                LastError = result - currentRes;

                var correction = (LastError / currentRes) * Smoothing;

                weight += correction;
            }
        }

        public static class ResearchProcess
        {
            public static decimal SimpleDecimalProcess(decimal smoothing, bool train, (decimal, decimal) trainingInput, decimal input)
            {
                Neuron neuron = new Neuron();

                if (train)
                {
                    neuron.Smoothing = smoothing;

                    SimpleTraining.Train(neuron, trainingInput.Item1, trainingInput.Item2);
                }

                return neuron.ProcessInput(input);
            }
        }

        public static class SimpleTraining
        {
            public static void Train(Neuron neuron, decimal input, decimal result)
            {
                Console.WriteLine($"Training has begun\n");
                
                int i = 0;

                do
                {
                    i++;
                    neuron.SetWeight(input, result);
                    
                } while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

                Console.WriteLine($"Training completed\n");
            }

            public static async Task TrainAsync(Neuron neuron, decimal input, decimal result)
            {
                await Task.Run(() => { Train(neuron, input, result); });
            }
        }
    }
}
