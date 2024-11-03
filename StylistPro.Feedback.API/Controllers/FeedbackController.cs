using StylistPro.Feedback.Application.Dtos;
using StylistPro.Feedback.Domain.Entities;
using StylistPro.Feedback.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StylistPro.Feedback.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackApplicationService _feedbackApplicationService;

        public FeedbackController(IFeedbackApplicationService feedbackApplicationService)
        {
            _feedbackApplicationService = feedbackApplicationService;
        }

        /// <summary>
        /// Método para obter todos os dados de feedbacks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<FeedbackEntity>>]
        public IActionResult Get()
        {
            var feedbacks = _feedbackApplicationService.ObterTodosFeedbacks();

            if (feedbacks is not null)
                return Ok(feedbacks);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Método para obter um feedback
        /// </summary>
        /// <param name="id">Identificador do feedback</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<FeedbackEntity>]

        public IActionResult GetPorId(int id)
        {
            var feedbacks = _feedbackApplicationService.ObterFeedbackPorId(id);

            if (feedbacks is not null)
                return Ok(feedbacks);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Métodos para salvar o feedback
        /// </summary>
        /// <param name="entity">Modelo de dados do Feedback</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<FeedbackEntity>]
        public IActionResult Post(FeedbackDto entity)
        {
            try
            {
                var feedbacks = _feedbackApplicationService.SalvarDadosFeedback(entity);

                if (feedbacks is not null)
                    return Ok(feedbacks);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Métodos para editar o feedback
        /// </summary>
        /// <param name="id"> Identificador do Feedback</param>
        /// <param name="entity">Modelo de dados do Feedback</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<FeedbackEntity>]
        public IActionResult Put(int id, [FromBody] FeedbackDto entity)
        {
            try
            {
                var feedbacks = _feedbackApplicationService.EditarDadosFeedback(id, entity);

                if (feedbacks is not null)
                    return Ok(feedbacks);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Método para deletar um feedback
        /// </summary>
        /// <param name="id">Identificador do feedback</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<FeedbackEntity>]

        public IActionResult Delete(int id)
        {
            var feedbacks = _feedbackApplicationService.DeletarDadosFeedback(id);

            if (feedbacks is not null)
                return Ok(feedbacks);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}
