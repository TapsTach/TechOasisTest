using System.ComponentModel.DataAnnotations;

namespace TechOasisTest.Shared.Entities
{
    /// <summary>
    /// Defines the <see cref="ContactDetail" />.
    /// </summary>
    public class ContactDetail
    {
        /// <summary>
        /// Gets or sets the ContactDetailID.
        /// </summary>
        [Key]
        public long ContactDetailID { get; set; }

        /// <summary>
        /// Gets or sets the Email address.
        /// </summary>
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Phone number.
        /// </summary>
        [MaxLength(50)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the WebSite.
        /// </summary>
        [MaxLength(50)]
        public string WebSite { get; set; }
    }
}
