namespace Gyoza
{
    /// <summary>
    /// Result with a state
    /// </summary>
    public class Result : IResult
    {
        /// <summary>
        /// Initialize a new empty instance of Result class
        /// </summary>
        public Result()
        {
            State = State.Empty;
        }

        /// <summary>
        /// Initialize a new instance of Result class with a State
        /// </summary>
        /// <param name="state">Result state</param>
        public Result(State expected)
        {
            State = expected;
        }

        /// <summary>
        /// Result state
        /// </summary>
        public State State { get; }
    }
}