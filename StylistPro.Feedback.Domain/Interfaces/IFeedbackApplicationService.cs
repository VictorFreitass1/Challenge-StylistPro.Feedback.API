using StylistPro.Feedback.Domain.Entities;
using StylistPro.Feedback.Domain.Interfaces.Dtos;

namespace StylistPro.Feedback.Domain.Interfaces
{
    public interface IFeedbackApplicationService
    { 
    IEnumerable<FeedbackEntity> ObterTodosFeedbacks();
    FeedbackEntity? ObterFeedbackPorId(int id);
    FeedbackEntity? SalvarDadosFeedback(IFeedbackDto entity);
    FeedbackEntity? EditarDadosFeedback(int id, IFeedbackDto entity);
    FeedbackEntity? DeletarDadosFeedback(int id);
    }
}