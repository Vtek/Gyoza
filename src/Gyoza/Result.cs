namespace Gyoza
{
    public class Result : IResult
    {
        public Result()
        {
            State = State.Empty;
        }

        public State State { get; }
    }
}