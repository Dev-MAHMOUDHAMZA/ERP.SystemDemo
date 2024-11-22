namespace ERP.Domain.Entities.MailSettings;
public class MailSetting
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string DisplayName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Host { get; set; } = string.Empty;

    public int Port { get; set; }

    public string? Api { get; set; }

    public bool IsApi { get; set; } = true;

    public bool IsActive { get; set; } = true;
}
