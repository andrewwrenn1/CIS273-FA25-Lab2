# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a C# .NET 9.0 solution containing multiple data structure and algorithm implementations as part of CIS 273 coursework. The solution includes:

- **PrayerScheduler**: Manages daily and non-daily prayers with scheduling logic
- **PostfixCalculator**: Evaluates postfix notation expressions
- **BalancedParentheses**: Validates balanced parentheses strings
- **ReverseFirstK**: Reverses the first K elements of a queue using only stacks and queues
- **UnitTests**: MSTest-based test suite covering all projects

## Project Structure

```
Lab2/
├── Lab2.sln                    # Solution file
├── PrayerScheduler/            # Prayer scheduling library
├── PostfixCalculator/          # Postfix expression evaluator
├── BalancedParentheses/        # Parentheses validation
├── ReverseFirstK/              # Queue manipulation utility
└── UnitTests/                  # Test project referencing all above
```

## Build and Test Commands

**Build the solution:**
```bash
dotnet build Lab2.sln
```

**Run all unit tests:**
```bash
dotnet test UnitTests/UnitTests.csproj
```

**Run tests for a specific project** (e.g., ReverseFirstK):
```bash
dotnet test UnitTests/UnitTests.csproj --filter "ClassName=UnitTests.ReverseFirstKTests"
```

**Build a specific project:**
```bash
dotnet build PostfixCalculator/PostfixCalculator.csproj
```

## Architecture Notes

### Shared Patterns

Each implementation project follows this structure:
- `Program.cs` contains the main class with static methods/logic
- All projects target .NET 9.0 with implicit usings and nullable reference types enabled
- No external dependencies beyond the standard .NET library

### UnitTests Project

- Uses MSTest framework (Microsoft.NET.Test.Sdk, MSTest.TestAdapter, MSTest.TestFramework)
- Contains project references to all implementation projects: PrayerScheduler, PostfixCalculator, BalancedParentheses, and ReverseFirstK
- Test classes are named with the pattern `{ProjectName}Tests` (e.g., `PostfixCalculatorTests`, `ReverseFirstKTests`)
- Each test is marked with `[TestMethod]` attribute

### Implementation Projects

- **PrayerScheduler**: Manages three collections (DailyPrayers list, NonDailyPrayers queue, AnsweredPrayers list). Core methods include `AddPrayer()`, `AnswerPrayer()`, and `GetPrayers()`. Uses a custom `Prayer` class and `DuplicateIDException`.
- **PostfixCalculator**: The `Evaluate(string)` method must return `double?` (nullable double), returning null for invalid expressions
- **BalancedParentheses**: The `IsBalanced(string)` method validates parentheses matching
- **ReverseFirstK**: The `ReverseFirstK<T>()` generic method reverses only the first K elements of a queue using only stack and queue operations, with documented edge cases (k > length, k < 0)

## Key Testing Patterns

- Tests use `Assert.AreEqual()` for single values
- Tests use `CollectionAssert.AreEqual()` for queue/collection comparisons
- PostfixCalculator tests check both valid expressions and null cases (empty strings, invalid syntax)
- ReverseFirstK tests verify correct reversal and restore operations
