

namespace ERP.Infrastructure.ViewModels;
public class LoginViewModel
{
    public string Email { get; set; } = string.Empty;
    public required string Password { get; set; }
    public bool RememberMe { get; set; }
}

public class ForgetPasswordViewModel
{
    public string UserNationalId { get; set; } = string.Empty;
}
