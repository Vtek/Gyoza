namespace Gyoza
{
    /// <summary>
    /// Define a result with a state
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Result state
        /// </summary>
        State State { get; }
    }
}