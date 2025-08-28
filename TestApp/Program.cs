using System;
using System.Collections.Generic;
using System.Linq;
using LexoAlgorithm;

class Program {
    static void Main() {
        Console.WriteLine("=== Base64 LexoRank with More Characters ===");
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
        
        Console.WriteLine("\n=== Testing Refresh Functionality ===");
        
        // Test refresh function
        var refreshedRank = LexoRank.Refresh(LexoRankBucket.Min());
        Console.WriteLine($"Refreshed rank: {refreshedRank.Format()}");
        
        // Test with multiple ranks
        var ranks = new List<LexoRank>();
        var current = LexoRank.Min();
        for (int i = 0; i < 5; i++)
        {
            current = current.GenNext();
            ranks.Add(current);
        }
        
        Console.WriteLine("\nOriginal ranks:");
        foreach (var rank in ranks)
        {
            Console.WriteLine($"  {rank.Format()}");
        }
        
        // Check if they need refresh
        bool needsRefresh = LexoRank.NeedsRefresh(ranks);
        Console.WriteLine($"Needs refresh: {needsRefresh}");
        
        // Refresh the ranks
        var refreshedRanks = LexoRank.RefreshRanks(ranks, LexoRankBucket.Min()).ToList();
        Console.WriteLine("\nRefreshed ranks:");
        foreach (var rank in refreshedRanks)
        {
            Console.WriteLine($"  {rank.Format()}");
        }
    }
}
