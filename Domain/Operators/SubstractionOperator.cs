using Domain.Base;

namespace Domain.Operators
{
    public class SubstractionOperator : Operator
    {
        public override string MathRepresentation => "-" + Value.GetValue() + Variable;

        public override Operator Inverse => new AdditionOperator(Value, Variable);

        public override bool ApplyGlobalTransformation => false;

        public SubstractionOperator(OperatorValue value, string? variable) 
            : base(value, variable)
        {
        }
    }
}
