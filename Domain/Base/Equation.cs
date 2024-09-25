using Domain.Operators;

namespace Domain.Base
{
    public class Equation
    {
        public List<Operator> Left { get; set; }

        public List<Operator> Right { get; set; }

        public Equation(List<Operator> left, List<Operator> right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString() => GetLeftValues() + "=" + GetRihtValues();

        public string GetLeftValues() => string.Join(null, Left.Select(_ => _.MathRepresentation));

        public string GetRihtValues() => string.Join(null, Right.Select(_ => _.MathRepresentation));

        public Equation IvertElement(Operator element, List<Operator> source)
        {
            if (source == Left)
            {
                Left.Remove(element);

                Right.Add(element.Inverse);

                return this;
            }

            if (source == Right)
            {
                Right.Remove(element);

                Left.Add(element.Inverse);

                return this;
            }

            throw new Exception("The provided source has not recognized as a valid one for an equation.");
        }

        public Equation ApplyGlobalTransformation(Operator element, List<Operator> source)
        {
            if (source == Left)
            {
                Left.Remove(element);

                Left.Add(new AdditionOperator(1, element.Variable)); // TODO: Validar Consistencia de esta afirmación

                element.Inverse.SetInverseValue(Right);

                Right.Clear();

                Right.Add(element.Inverse);

                return this;
            }

            if (source == Right)
            {
                Right.Remove(element);

                Right.Add(new AdditionOperator(1, element.Variable)); // TODO: Validar Consistencia de esta afirmación

                element.Inverse.SetInverseValue(Left);

                Left.Clear();

                Left.Add(element.Inverse);

                return this;
            }

            throw new Exception("The provided source has not recognized as a valid one for an equation.");
        }

        public List<Equation> SolveForAll(string variable)
        {
            List<Operator> termsWithVarible = Left.Where(_ => _.Variable == variable).ToList();

            List<Equation> solves = new();


            foreach (Operator term in termsWithVarible)
            {
                Equation solution = Solve(term);

                solves.Add(solution);
            }

            return solves;
        }


        public Equation Solve(Operator term)
        {
            Operator termInEquation = Left.FirstOrDefault(_ => _.Equals(term))
                                        ?? throw new Exception("The provided term for te equation solver was not found in the left definition.");

            List<Operator> termsToMove = Left.Where(_ => !_.Equals(termInEquation)).ToList();

            foreach (Operator termToMove in termsToMove)
            {
                if (!termToMove.ApplyGlobalTransformation)
                    IvertElement(termToMove, Left);
                else
                    ApplyGlobalTransformation(termToMove, Left);
            }

            if (termInEquation.ApplyGlobalTransformation)
                ApplyGlobalTransformation(termInEquation, Left);

            return this;
        }

        
    }
}
