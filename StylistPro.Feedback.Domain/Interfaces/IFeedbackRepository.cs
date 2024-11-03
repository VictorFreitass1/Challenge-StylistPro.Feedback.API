using StylistPro.Feedback.Domain.Entities;

namespace StylistPro.Feedback.Domain.Interfaces
{
    public interface IFeedbackRepository
    {
        IEnumerable<FeedbackEntity> ObterTodos();
        FeedbackEntity? ObterPorId(int id);
        FeedbackEntity? SalvarDados(FeedbackEntity entity);
        FeedbackEntity? EditarDados(FeedbackEntity entity);
        FeedbackEntity? DeletarDados(int id);
    }
}