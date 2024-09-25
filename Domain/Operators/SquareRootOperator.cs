using Domain.Base;

namespace Domain.Operators
{
    public class SquareRootOperator : Operator
    {
        public override string MathRepresentation => "√(" + Value.GetValue() + Variable + ")";

        public override Operator? Inverse => new SquareOperator(0, Variable);

        public override bool ApplyGlobalTransformation => true;

        public SquareRootOperator(OperatorValue value, string? variable) 
            : base(value, variable)
        {
        }
    }
}
