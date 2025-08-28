# LexoRank for .NET

[![Build Status](https://travis-ci.org/yannickrondeau/lexorank-dotnet.svg?branch=master)](https://travis-ci.org/yannickrondeau/lexorank-dotnet)

A .NET implementation of the LexoRank algorithm used by Atlassian Jira for issue ordering. This library provides lexicographic ordering with enhanced Base64 character support and token refreshing capabilities.

## ✨ Recent Enhancements

### 🚀 Enhanced Character Set (Base64)
- **78% more characters**: Upgraded from Base36 (36 chars) to Base64 (64 chars)
- **Rich character variety**: Now supports `0-9A-Za-z^_` character set
- **Better distribution**: More characters mean better spacing and fewer collisions

### 🔄 Token Refreshing
- **Refresh single ranks**: Generate fresh ranks to prevent exhaustion
- **Bulk refresh**: Redistribute multiple ranks evenly across the space
- **Density detection**: Automatically detect when ranks need refreshing
- **Prevents rank exhaustion**: Maintains system health over time

## Usage

### Basic Operations

```csharp
using LexoAlgorithm;

// Create initial ranks
var min = LexoRank.Min();           // 0|000000:
var max = LexoRank.Max();           // 0|zzzzzz:
var middle = LexoRank.Middle();     // 0|Vzzzzz:

// Generate sequential ranks
var next = min.GenNext();           // 0|100000:
var prev = max.GenPrev();           // 0|zzzzzW:

// Create rank between two existing ranks
var between = min.Between(next);    // 0|0W0000:
```

### Enhanced Base64 Features

```csharp
// Rich character variety with Base64
var ranks = new List<LexoRank>();
var current = LexoRank.Min();
for (int i = 0; i < 5; i++)
{
    current = current.GenNext();
    ranks.Add(current);
    Console.WriteLine(current.Format());
}
// Output: 0|100000:, 0|100008:, 0|10000G:, 0|10000O:, 0|10000W:
```

### Token Refreshing

```csharp
// Generate a fresh rank
var refreshed = LexoRank.Refresh(LexoRankBucket.Min());

// Check if ranks need refreshing
var needsRefresh = LexoRank.NeedsRefresh(ranks);

// Refresh multiple ranks for even distribution
var refreshedRanks = LexoRank.RefreshRanks(ranks, LexoRankBucket.Min());
```

### Working with Buckets

```csharp
// Move between buckets
var rank = LexoRank.Min();
var nextBucket = rank.InNextBucket();
var prevBucket = rank.InPrevBucket();

// Parse existing ranks
var parsed = LexoRank.Parse("1|100000:");
```

## Key Features

- **Enhanced Base64 encoding** with 64 characters (0-9A-Za-z^_)
- **Token refreshing** to prevent rank space exhaustion
- **Bucket support** for managing different rank spaces
- **High precision** lexicographic ordering
- **Thread-safe** operations
- **Backward compatible** with existing rank strings

## Installation

```bash
dotnet add package LexoRank
```

## Algorithm Details

LexoRank uses a modified Base64 numeral system to generate lexicographically ordered strings. Each rank consists of:

1. **Bucket identifier** (0, 1, or 2)
2. **Separator** (|)
3. **Base64 decimal value** with padding and precision formatting
4. **Terminator** (:)

Example: `0|Vzzzzz:` where:
- `0` = bucket
- `|` = separator  
- `Vzzzzz` = Base64 encoded position
- `:` = terminator

The refresh functionality helps maintain optimal rank distribution and prevents the rank space from becoming too dense over time.

## Contributing

Feel free to submit issues and enhancement requests!