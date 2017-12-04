namespace Gyoza
{
    public class ValueResult : IResult, IValue
    {
        public ValueResult(State state, object value)
        {
            State = state;
            Value = value;
        }

        public State State { get; }
        public object Value { get; }
    }
}