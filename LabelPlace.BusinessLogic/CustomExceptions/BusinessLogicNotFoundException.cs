using System;

namespace LabelPlace.BusinessLogic.CustomExceptions
{
    public class BusinessLogicNotFoundException : Exception
    {
        public BusinessLogicNotFoundException(string message)
            : base(message)
        {
        }
    }
}
