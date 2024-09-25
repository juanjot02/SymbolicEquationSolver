namespace Domain.Base
{
    public abstract class Operator
    {
        public abstract string MathRepresentation { get; }

        public abstract Operator? Inverse { get; }

        public abstract bool ApplyGlobalTransformation { get; }

        public OperatorValue Value { get; set; }

        public string? Variable { get; }

        protected Operator(OperatorValue value, string? variable)
        {
            Value = value;
            Variable = variable;
        }

        public override bool Equals(object? obj) => Equals(obj as Operator);

        public bool Equals(Operator? @operator)
        {
            if (@operator is null)
                return false;

            if (ReferenceEquals(this, @operator)) 
                return true;

            if (GetType() != @operator.GetType())
                return false;

            return Value.Equals(@operator.Value) && Variable == @operator.Variable;
        }

        public override int GetHashCode() => (Value, Variable).GetHashCode();

        public void SetInverseValue(OperatorValue value)
        {
            if (Inverse is not null)
                Inverse.Value = value;
        }
    }
}
