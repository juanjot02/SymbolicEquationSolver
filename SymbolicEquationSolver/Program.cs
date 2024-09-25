// See https://aka.ms/new-console-template for more information
using Domain.Base;
using Domain.Operators;

List<Operator> left = new()
{
    new SquareRootOperator(0, "x"),
    new SubstractionOperator(1, "x")
};

List<Operator> right = new()
{
    new AdditionOperator(0)
};


Equation equation = new(left, right);

Console.WriteLine(equation.ToString());

equation.Solve(new SquareRootOperator(0, "x"));

Console.WriteLine(equation.ToString());

//equation.IvertElement(left[0], left);

//Console.WriteLine(equation.ToString());

//equation.IvertElement(left[0], left);
//equation.IvertElement(right[0], right);

//Console.WriteLine(equation.ToString());
