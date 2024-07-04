using System.ComponentModel.DataAnnotations;

namespace ServitiaTest_Backend_Domain
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Recipient { get; set; }

        [Required]
        [MaxLength(80)]
        public string Sender { get; set; }

        public string Content { get; set; }

        [Required]
        public bool Read { get; set; } = false;

        public DateTime CreationDate { get; set; }

        public DateTime? LastModification { get; set; }

        public Message()
        {
            Recipient = string.Empty;
            Sender = string.Empty;
            Content = string.Empty;
            Read = false;
            CreationDate = DateTime.Now;
            Id = Guid.NewGuid();

        }
    }

}