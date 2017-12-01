using System;

namespace Gyoza
{
    [Flags]
    public enum State
    {
        None = 0,
        DomainError = 1,
        Empty = 2,
        Success = 4,
        TechnicalError = 8
    }
}