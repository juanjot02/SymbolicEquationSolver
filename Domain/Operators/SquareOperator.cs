using Domain.Base;

namespace Domain.Operators
{
    public class SquareOperator : Operator
    {
        public override string MathRepresentation => "(" + Value.GetValue() + Variable + ")²";

        public override Operator? Inverse => new SquareRootOperator(0, Variable);

        public override bool ApplyGlobalTransformation => true;

        public SquareOperator(OperatorValue value, string? variable) 
            : base(value, variable)
        {
        }
    }
}
