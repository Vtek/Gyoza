namespace Gyoza
{
    public class Result : IResult
    {
        public Result()
        {
            State = State.Empty;
        }

        public Result(State expected)
        {
            State = expected;
        }

        public State State { get; }
    }
}