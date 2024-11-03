using StylistPro.Feedback.Domain.Interfaces.Dtos;
using FluentValidation;


namespace StylistPro.Feedback.Application.Dtos
{
    public class FeedbackDto : IFeedbackDto
    {
        public int Avaliacao { get; set; }
        public string Comentario { get; set; }

        public void Validate()
        {
            var validateResult = new FeedbackDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FeedbackDtoValidation : AbstractValidator<FeedbackDto>
    {
        public FeedbackDtoValidation()
        {
            RuleFor(x => x.Avaliacao)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Avaliacao)} não pode ser vazio");

            RuleFor(x => x.Comentario)
                .NotEmpty().WithMessage(x => $"O campo {nameof(x.Comentario)} não pode ser vazio");
        }
    }
}