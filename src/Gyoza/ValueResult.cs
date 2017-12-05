namespace Gyoza
{
    /// <summary>
    /// Result with a value
    /// </summary>
    public class ValueResult : Result, IValue
    {
        /// <summary>
        /// Create a new instance of ValueResult class
        /// </summary>
        /// <param name="state">Result state</param>
        /// <param name="value">Result value</param>
        public ValueResult(State state, object value)
            : base(state)
        {
            Value = value;
        }

        /// <summary>
        /// Value
        /// </summary>
        public object Value { get; }
    }
}