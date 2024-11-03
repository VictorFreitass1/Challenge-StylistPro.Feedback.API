using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StylistPro.Feedback.Domain.Entities
{
    [Table("TB_FEEDBACK")]
    public class FeedbackEntity
    {
        [Key]
        public int Id { get; set; } 
        public int Avaliacao { get; set; }
        public string Comentario { get; set; }
    }
}
