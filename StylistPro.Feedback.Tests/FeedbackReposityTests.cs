using StylistPro.Feedback.Data.AppData;
using StylistPro.Feedback.Data.Repositories;
using StylistPro.Feedback.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StylistPro.Feedback.Tests
{
    public class FeedbackRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationContext(_options);
            _feedbackRepository = new FeedbackRepository(_context);
        }

        [Fact]
        public void SalvarDados_DeveAdicionarFeedbackERetornarFeedbackEntity()
        {
            // Arrange
            var feedback = new FeedbackEntity { Avaliacao = 5, Comentario = "Muito Bom" };

            // Act
            var resultado = _feedbackRepository.SalvarDados(feedback);

            // Assert
            var feedbackNoDb = _context.Feedback.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(feedbackNoDb);
            Assert.Equal(feedback.Avaliacao, feedbackNoDb.Avaliacao);
            Assert.Equal(feedback.Comentario, feedbackNoDb.Comentario);
        }

        [Fact]
        public void EditarDados_DeveAtualizarFeedbackERetornarFeedbackEntity_QuandoFeedbackExiste()
        {
            // Arrange
            var feedback = new FeedbackEntity { Avaliacao = 4, Comentario = "Bom" };
            _context.Feedback.Add(feedback);
            _context.SaveChanges();

            feedback.Avaliacao = 3;
            feedback.Comentario = "Regular";

            // Act
            var resultado = _feedbackRepository.EditarDados(feedback);

            // Assert
            var feedbackNoDb = _context.Feedback.FirstOrDefault(c => c.Id == feedback.Id);
            Assert.NotNull(feedbackNoDb);
            Assert.Equal(3, feedbackNoDb.Avaliacao);
            Assert.Equal("Regular", feedbackNoDb.Comentario);
        }

        [Fact]
        public void ObterPorId_DeveRetornarFeedbackEntity_QuandoFeedbackExiste()
        {
            // Arrange
            var feedback = new FeedbackEntity { Avaliacao = 5, Comentario = "Excelente" };
            _context.Feedback.Add(feedback);
            _context.SaveChanges();

            // Act
            var resultado = _feedbackRepository.ObterPorId(feedback.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(feedback.Id, resultado.Id);
            Assert.Equal(feedback.Avaliacao, resultado.Avaliacao);
            Assert.Equal(feedback.Comentario, resultado.Comentario);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeFeedbacks_QuandoExistiremFeedbacks()
        {
            // Arrange
            _context.Feedback.RemoveRange(_context.Feedback);
            _context.SaveChanges();

            var feedbacks = new List<FeedbackEntity>
            {
                new FeedbackEntity { Avaliacao = 5, Comentario = "Ótimo" },
                new FeedbackEntity { Avaliacao = 4, Comentario = "Bom" }
            };
            _context.Feedback.AddRange(feedbacks);
            _context.SaveChanges();

            // Act
            var resultado = _feedbackRepository.ObterTodos();

            // Assert
            Assert.Equal(feedbacks.Count, resultado.Count());
            Assert.Contains(resultado, f => f.Avaliacao == 5);
            Assert.Contains(resultado, f => f.Avaliacao == 4);
        }

        [Fact]
        public void DeletarDados_DeveRemoverFeedbackRetornarFeedbackEntity_QuandoFeedbackExiste()
        {
            // Arrange
            var feedback = new FeedbackEntity { Avaliacao = 2, Comentario = "Ruim" };
            _context.Feedback.Add(feedback);
            _context.SaveChanges();

            // Act
            var resultado = _feedbackRepository.DeletarDados(feedback.Id);

            // Assert
            var feedbackNoDb = _context.Feedback.FirstOrDefault(c => c.Id == feedback.Id);

            Assert.Null(feedbackNoDb);
            Assert.Equal(feedback, resultado);
        }
    }
}
