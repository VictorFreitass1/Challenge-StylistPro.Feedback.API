namespace StylistPro.Feedback.Domain.Interfaces.Dtos
{
    public interface IFeedbackDto
    {
        public int Avaliacao { get; set; }
        public string Comentario { get; set; }
        void Validate();
    }
}
