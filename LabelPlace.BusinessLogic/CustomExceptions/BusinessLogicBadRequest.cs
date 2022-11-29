using System;

namespace LabelPlace.BusinessLogic.CustomExceptions
{
    public class BusinessLogicBadRequest : Exception
    {
        public BusinessLogicBadRequest(string message)
            : base(message)
        {
        }
    }
}
