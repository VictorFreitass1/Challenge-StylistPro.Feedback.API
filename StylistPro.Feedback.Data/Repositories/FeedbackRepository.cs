using StylistPro.Feedback.Data.AppData;
using StylistPro.Feedback.Domain.Entities;
using StylistPro.Feedback.Domain.Interfaces;

namespace StylistPro.Feedback.Data.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationContext _context;

        public FeedbackRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FeedbackEntity? DeletarDados(int id)
        {
            var feedback = _context.Feedback.Find(id);

            if (feedback is not null)
            {
                _context.Feedback.Remove(feedback);
                _context.SaveChanges();

                return feedback;
            }

            return null;
        }

        public FeedbackEntity? EditarDados(FeedbackEntity entity)
        {
            var feedback = _context.Feedback.Find(entity.Id);

            if (feedback is not null)
            {
                feedback.Avaliacao = entity.Avaliacao;
                feedback.Comentario = entity.Comentario;

                _context.Feedback.Update(feedback);
                _context.SaveChanges();

                return feedback;
            }

            return null;
        }

        public FeedbackEntity? ObterPorId(int id)
        {
            var feedback = _context.Feedback.Find(id);

            if (feedback is not null)
            {

                return feedback;
            }

            return null;
        }

        public IEnumerable<FeedbackEntity> ObterTodos()
        {
            var feedbacks = _context.Feedback.ToList();

            return feedbacks;
        }

        public FeedbackEntity? SalvarDados(FeedbackEntity entity)
        {
            _context.Feedback.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
