

namespace ERP.Domain.Enums;
public static class EnumHelper
{
    public enum eOrder
    {
        Pending = 0,
        Paid = 1,
        Coupon = 2
    }
    
    public enum eCurrency
    {
        EG,
        Kw,
    }
    public enum eLoginResult
    {
        UserInactive = 1,
        OnlyEmployee = 2,
        WrongPasswordEmail = 3,
        SuccessfulLogin = 4,
        UserNotFound =5,
        Error
    }
    public enum eMsgResult
    {

        Successful = 1,
        UserNotFound,
        Error
    }
}
