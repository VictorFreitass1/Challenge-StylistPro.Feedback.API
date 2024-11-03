using Moq;
using StylistPro.Feedback.Application.Services;
using StylistPro.Feedback.Domain.Entities;
using StylistPro.Feedback.Domain.Interfaces;
using StylistPro.Feedback.Domain.Interfaces.Dtos;

namespace StylistPro.Feedback.Tests
{
    public class FeedbackApplicationServiceTests
    {
        private readonly Mock<IFeedbackRepository> _repositoryMock;
        private readonly FeedbackApplicationService _feedbackService;

        public FeedbackApplicationServiceTests()
        {
            _repositoryMock = new Mock<IFeedbackRepository>();
            _feedbackService = new FeedbackApplicationService(_repositoryMock.Object);
        }

        [Fact]
        public void SalvarDadosFeedback_DeveRetornarFeedbackEntity_QuandoAdicionarComSucesso()
        {
            // Arrange
            var feedbackDtoMock = new Mock<IFeedbackDto>();
            feedbackDtoMock.Setup(c => c.Avaliacao).Returns(100);
            feedbackDtoMock.Setup(c => c.Comentario).Returns("Excelente");

            var feedbackEsperado = new FeedbackEntity { Avaliacao = 100, Comentario = "Excelente" };

            _repositoryMock.Setup(r => r.SalvarDados(It.IsAny<FeedbackEntity>())).Returns(feedbackEsperado);

            // Act
            var resultado = _feedbackService.SalvarDadosFeedback(feedbackDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(feedbackEsperado.Avaliacao, resultado.Avaliacao);
            Assert.Equal(feedbackEsperado.Comentario, resultado.Comentario);
        }

        [Fact]
        public void EditarDadosFeedback_DeveRetornarFeedbackEntity_QuandoEditarComSucesso()
        {
            // Arrange
            var feedbackDtoMock = new Mock<IFeedbackDto>();
            feedbackDtoMock.Setup(c => c.Avaliacao).Returns(80);
            feedbackDtoMock.Setup(c => c.Comentario).Returns("Bom");

            var feedbackEsperado = new FeedbackEntity { Id = 1, Avaliacao = 80, Comentario = "Bom" };
            _repositoryMock.Setup(r => r.EditarDados(It.IsAny<FeedbackEntity>())).Returns(feedbackEsperado);

            // Act
            var resultado = _feedbackService.EditarDadosFeedback(1, feedbackDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(feedbackEsperado.Id, resultado.Id);
            Assert.Equal(feedbackEsperado.Avaliacao, resultado.Avaliacao);
            Assert.Equal(feedbackEsperado.Comentario, resultado.Comentario);
        }

        [Fact]
        public void ObterFeedbackPorId_DeveRetornarFeedbackEntity_QuandoFeedbackExiste()
        {
            // Arrange
            var feedbackEsperado = new FeedbackEntity { Id = 1, Avaliacao = 90, Comentario = "Muito Bom" };
            _repositoryMock.Setup(r => r.ObterPorId(1)).Returns(feedbackEsperado);

            // Act
            var resultado = _feedbackService.ObterFeedbackPorId(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(feedbackEsperado.Id, resultado.Id);
            Assert.Equal(feedbackEsperado.Avaliacao, resultado.Avaliacao);
            Assert.Equal(feedbackEsperado.Comentario, resultado.Comentario);
        }

        [Fact]
        public void ObterTodosFeedbacks_DeveRetornarListaDeFeedbacks_QuandoExistiremFeedbacks()
        {
            // Arrange
            var feedbacksEsperados = new List<FeedbackEntity>
            {
                new FeedbackEntity { Id = 1, Avaliacao = 95, Comentario = "Ótimo" },
                new FeedbackEntity { Id = 2, Avaliacao = 85, Comentario = "Muito Bom" }
            };
            _repositoryMock.Setup(r => r.ObterTodos()).Returns(feedbacksEsperados);

            // Act
            var resultado = _feedbackService.ObterTodosFeedbacks();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal(feedbacksEsperados.First().Avaliacao, resultado.First().Avaliacao);
            Assert.Equal(feedbacksEsperados.First().Comentario, resultado.First().Comentario);
        }

        [Fact]
        public void DeletarDadosFeedback_DeveRetornarFeedbackEntity_QuandoRemoverComSucesso()
        {
            // Arrange
            var feedbackEsperado = new FeedbackEntity { Id = 1, Avaliacao = 60, Comentario = "Regular" };
            _repositoryMock.Setup(r => r.DeletarDados(1)).Returns(feedbackEsperado);

            // Act
            var resultado = _feedbackService.DeletarDadosFeedback(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(feedbackEsperado.Id, resultado.Id);
            Assert.Equal(feedbackEsperado.Avaliacao, resultado.Avaliacao);
            Assert.Equal(feedbackEsperado.Comentario, resultado.Comentario);
        }
    }
}
