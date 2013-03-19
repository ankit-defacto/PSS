
namespace PSS.WebWithAuth.Models
{
    using System.ComponentModel.DataAnnotations;
    using DataAnnotationsExtensions;

    /// <summary>
    /// Contact form message
    /// </summary>
    public class ContactMessage
    {
        /// <summary>
        /// Gets or sets sender email address
        /// </summary>
        [DataType(DataType.EmailAddress), Display(Prompt = "Enter your e-mail adress")]
        [Email]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        [DataType(DataType.MultilineText), Display(Prompt = "Your message:")]
        [StringLength(1000)]
        [Required]
        public string Message { get; set; }
    }
}