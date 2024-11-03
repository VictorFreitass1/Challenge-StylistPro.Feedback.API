using StylistPro.Feedback.Domain.Entities;
using StylistPro.Feedback.Domain.Interfaces;
using StylistPro.Feedback.Domain.Interfaces.Dtos;

namespace StylistPro.Feedback.Application.Services
{
    public class FeedbackApplicationService : IFeedbackApplicationService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackApplicationService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }
        public FeedbackEntity? DeletarDadosFeedback(int id)
        {
            return _feedbackRepository.DeletarDados(id);
        }

        public FeedbackEntity? EditarDadosFeedback(int id, IFeedbackDto entity)
        {
            entity.Validate();

            return _feedbackRepository.EditarDados(new FeedbackEntity
            {
                Id = id,
                Avaliacao = entity.Avaliacao,
                Comentario = entity.Comentario,
            });
        }

        public FeedbackEntity? ObterFeedbackPorId(int id)
        {
            return _feedbackRepository.ObterPorId(id);
        }

        public IEnumerable<FeedbackEntity> ObterTodosFeedbacks()
        {
            return _feedbackRepository.ObterTodos();
        }

        public FeedbackEntity? SalvarDadosFeedback(IFeedbackDto entity)
        {
            entity.Validate();

            return _feedbackRepository.SalvarDados(new FeedbackEntity
            {
                Avaliacao = entity.Avaliacao,
                Comentario = entity.Comentario,
            });
        }
    }
}
