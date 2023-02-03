using System;

namespace LabelPlace.BusinessLogic.CustomExceptions
{
    public class BusinessLogicAlreadyExistsException : Exception
    {
        public BusinessLogicAlreadyExistsException(string message)
            : base(message)
        {
        }
    }
}
