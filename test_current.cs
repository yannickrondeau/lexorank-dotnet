using System;
using LexoAlgorithm;

class Program {
    static void Main() {
        var min = LexoRank.Min();
        var max = LexoRank.Max();
        var middle = LexoRank.Middle();
        
        Console.WriteLine($"Min: {min.Format()}");
        Console.WriteLine($"Max: {max.Format()}");
        Console.WriteLine($"Middle: {middle.Format()}");
        
        var next1 = min.GenNext();
        var next2 = next1.GenNext();
        var between = min.Between(next1);
        
        Console.WriteLine($"Next1: {next1.Format()}");
        Console.WriteLine($"Next2: {next2.Format()}");
        Console.WriteLine($"Between Min and Next1: {between.Format()}");
        
        Console.WriteLine($"Current numeral system: {LexoRank.NumeralSystem.Name}");
        Console.WriteLine($"Current base: {LexoRank.NumeralSystem.GetBase()}");
    }
}
