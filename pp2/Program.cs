using pp2;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    private static void Main(string[] args)
    {
        SingleNeuron.Neuron neuron = new SingleNeuron.Neuron();

        neuron.Smoothing = 0.00001m;

        var path = "C:/Users/alpha/source/repos/pp2/pp2/TestImages/a.png";

        var intsArray = ImageConvert.Convert(new Bitmap(path));

        int item = 0;

        intsArray.ToList().ForEach(i => {
            item += i;
        });

        var neuronData = neuron.ProcessInput(item);

        Console.WriteLine(neuronData);
    }

    private void test1()
    {
        SingleNeuron.Neuron neuron = new SingleNeuron.Neuron();

        neuron.Smoothing = 0.00001m;

        decimal input = 100; //долларов

        decimal rightInput = 374.39m; //шекели

        SingleNeuron.SimpleTraining.Train(neuron, input, rightInput);

        Console.WriteLine(MathF.Round((float)neuron.ProcessInput(100), 5));

        Console.WriteLine(MathF.Round((float)neuron.ProcessInput(200), 5));

        Console.WriteLine(MathF.Round((float)neuron.ProcessInput(95.3232m), 5));
    }
}