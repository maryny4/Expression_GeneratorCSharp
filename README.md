# Expression_GeneratorCSharp

## Overview

The `Expression_GeneratorCSharp` is a C# utility designed to generate random mathematical expressions and evaluate their results. The program can produce expressions involving addition, subtraction, multiplication, and division, with or without parentheses. It also includes functionality to generate specific floating-point expressions that approximate a given target result.

## Features

### 1. Generate Random Expressions
- **Addition and Subtraction**: Generates expressions with two operands using `+` and `-` operations.
- **Multiplication and Division**: Generates expressions with two operands using `*` and `/` operations.
- **Expressions Without Brackets**: Generates expressions with three operands and two operations, ensuring the result is an integer within a specified range.
- **Expressions With Brackets**: Generates expressions with three operands and two operations, with random placement of parentheses, ensuring the result is an integer within a specified range.

### 2. Calculate Expression Results
- Evaluates the generated expressions and returns their results.

### 3. Generate Specific Floating-Point Expressions
- Generates expressions involving two operands and one operation (`+`, `-`, `*`, or `/`) that approximate a given target floating-point result within a specified tolerance.

## Usage

### Generate and Evaluate Expressions

The `ExpressionGenerator` class provides various methods to generate and evaluate expressions.

```csharp
string additionSubtractionExpression = ExpressionGenerator.GenerateAdditionSubtractionExpression(-15, 15);
double additionSubtractionResult = ExpressionGenerator.CalculateExpression(additionSubtractionExpression);
Console.WriteLine($"{additionSubtractionExpression} = {additionSubtractionResult}");

string multiplicationDivisionExpression = ExpressionGenerator.GenerateMultiplicationDivisionExpression(1, 15);
double multiplicationDivisionResult = ExpressionGenerator.CalculateExpression(multiplicationDivisionExpression);
Console.WriteLine($"{multiplicationDivisionExpression} = {multiplicationDivisionResult}");

string expressionWithoutBrackets = ExpressionGenerator.GenerateExpressionWithoutBrackets(-15, 15, 1, 100);
double resultWithoutBrackets = ExpressionGenerator.CalculateExpression(expressionWithoutBrackets);
Console.WriteLine($"{expressionWithoutBrackets} = {resultWithoutBrackets}");

string expressionWithBrackets = ExpressionGenerator.GenerateExpressionWithBrackets(-15, 15, 1, 100);
double resultWithBrackets = ExpressionGenerator.CalculateExpression(expressionWithBrackets);
Console.WriteLine($"{expressionWithBrackets} = {resultWithBrackets}");
```

Example Output
```csharp
7 + 10 = 17
12 / 3 = 4
5 * 4 + 3 = 23
(10 + 2) * 3 = 36
3 / 12 = 0.25
10 * 0.1 = 1
20 / 40 = 0.5
1 - 4 = -3
```
