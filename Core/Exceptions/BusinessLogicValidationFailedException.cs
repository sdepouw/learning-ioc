using System;

namespace LearningIoC.Core.Exceptions
{
    public class BusinessLogicValidationFailedException : Exception
    {
        public BusinessLogicValidationFailedException()
            : base("Validation in core business logic failed.")
        { }
    }
}