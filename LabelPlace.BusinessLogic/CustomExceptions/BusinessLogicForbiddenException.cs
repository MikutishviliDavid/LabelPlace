using System;

namespace LabelPlace.BusinessLogic.CustomExceptions
{
    public class BusinessLogicForbiddenException : Exception
    {
        public BusinessLogicForbiddenException(string message)
            : base(message)
        {
        }
    }
}
