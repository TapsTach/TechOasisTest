using System.ComponentModel.DataAnnotations;

namespace TechOasisTest.Shared.Entities
{
    /// <summary>
    /// Defines the <see cref="JobSeekerProfile" />.
    /// </summary>
    public class JobSeekerProfile
    {
        /// <summary>
        /// Gets or sets the JobSeekerProfileID.
        /// </summary>
        public long JobSeekerProfileID { get; set; }

        /// <summary>
        /// Gets or sets the FirstName.
        /// </summary>
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Surname.
        /// </summary>
        [MaxLength(50)]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the Bio.
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// Gets or sets the ImageFilePath.
        /// </summary>
        [MaxLength(150)]
        public string ImageFilePath { get; set; }

        /// <summary>
        /// Gets or sets the ContactDetails.
        /// </summary>
        public ContactDetail ContactDetails { get; set; }

        /// <summary>
        /// Gets or sets the ContactDetailsID.
        /// </summary>
        public long ContactDetailsID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether CVRequested.
        /// </summary>
        public bool CVRequested { get; set; }
    }
}
