namespace Gyoza.Tests
{
    internal class ValueResult
    {
        private State expectedState;
        private string expectedValue;

        public ValueResult(State expectedState, string expectedValue)
        {
            this.expectedState = expectedState;
            this.expectedValue = expectedValue;
        }

        public object State { get; internal set; }
        public object Value { get; internal set; }
    }
}