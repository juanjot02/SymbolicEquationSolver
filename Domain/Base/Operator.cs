namespace Domain.Base
{
    public abstract class Operator
    {
        public abstract string MathRepresentation { get; }

        public Operator Inverse { get; }

    }
}
