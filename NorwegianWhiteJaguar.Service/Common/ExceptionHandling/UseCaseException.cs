using System;

namespace NorwegianWhiteJaguar.Service.Common.ExceptionHandling
{
    public class UseCaseException : Exception
    {
        public UseCaseException(string message)
      : base(message)
        {
        }
    }
}
