namespace Domain.Base
{
    public struct OperatorValue
    {
        internal decimal? ScalarValue;

        internal Operator? InterpolatedOperator;

        internal List<Operator>? OperatorList;

        public OperatorValue(decimal scalarValue) : this()
        {
            ScalarValue = scalarValue;
        }

        public OperatorValue(Operator interpolatedOperator) : this()
        {
            InterpolatedOperator = interpolatedOperator;
        }

        public OperatorValue(List<Operator> operatorList) : this()
        {
            OperatorList = operatorList;
        }

        public static implicit operator OperatorValue(decimal value) => new(value);

        public static implicit operator OperatorValue(Operator value) => new(value);

        public static implicit operator OperatorValue(List<Operator> values) => new(values);

        public object GetValue()
        {
            if (ScalarValue is not null)
                return ScalarValue;

            if (InterpolatedOperator is not null)
                return InterpolatedOperator.Value.GetValue();

            if (OperatorList is not null)
                return OperatorList.Select(_ => _.Value.GetValue()).ToList();

            throw new ArgumentNullException("The struct has no value defined");
        }
    }
}
