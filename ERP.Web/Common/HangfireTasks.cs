using ERP.Infrastructure.Data;

namespace ERP.Web.Common;

public class HangFireTasks
{
    //private readonly IUnitOfWork _unitOfWork;
    //private readonly ApplicationDbContext _context;
    //private readonly ILogger<HangFireTasks> _logger;

    //public HangFireTasks(IUnitOfWork unitOfWork, ApplicationDbContext context, ILogger<HangFireTasks> logger)
    //{
    //    _unitOfWork = unitOfWork;
    //    _logger = logger;
    //    _context = context;
    //}
    ////Add function
    //public async Task ChangeInternalMailsStatusToLate()
    //{
    //    try
    //    {
    //        var mails = _unitOfWork.InternalMailings.GetAllQueryable(m => m.DueDate != null && m.DueDate.Value.Date < DateTime.Now.Date
    //        && !(m.MailingStatusId.Equals((int)eMailingStatus.Saved) || m.MailingStatusId.Equals((int)eMailingStatus.Signed)
    //        || m.MailingStatusId.Equals((int)eMailingStatus.Exported) || m.MailingStatusId.Equals((int)eMailingStatus.Late))).ToList();
    //        foreach (var mail in mails)
    //            mail.MailingStatusId = (int)eMailingStatus.Late;

    //        _unitOfWork.InternalMailings.UpdateRangeAsync(mails.ToList());
    //        _unitOfWork.Complete();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex.Message);
    //        throw;
    //    }

    //}
    //public async Task UpdateExternalMailsStatusToLate()
    //{
    //    try
    //    {
    //        var mails = _unitOfWork.ExternalMailings.GetAllQueryable(m => m.DueDate != null && ((DateTime)m.DueDate).Date < DateTime.Now.Date && !(m.MailingStatusId.Equals((int)eMailingStatus.Saved) || m.MailingStatusId.Equals((int)eMailingStatus.Signed) || m.MailingStatusId.Equals((int)eMailingStatus.Exported) || m.MailingStatusId.Equals((int)eMailingStatus.Late))).ToList();
    //        foreach (var mail in mails)
    //            mail.MailingStatusId = (int)eMailingStatus.Late;


    //        _unitOfWork.ExternalMailings.UpdateRangeAsync(mails.ToList());
    //        _unitOfWork.Complete();

    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex.Message);
    //        throw;
    //    }

    //}
}

