using Domain.Base;

namespace Domain.Operators
{
    public class AdditionOperator : Operator
    {
        public override string MathRepresentation => "+" + Value.GetValue() + Variable;

        public override Operator Inverse => new SubstractionOperator(Value, Variable);

        public override bool ApplyGlobalTransformation => false;

        public AdditionOperator(OperatorValue value, string? variable = null) 
            : base(value, variable)
        {
        }
    }
}
