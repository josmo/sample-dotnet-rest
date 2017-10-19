
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample_dotnet_rest.models
{
    [Table("ref_APPLICATION_REGISTRATION")]
    public class Application
    {
        [Key]
        public int ApplicationID { get; set; }
        [Required]
        [StringLength(255)]
        public string ApplicationName { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(255)]
        public string ApplicationURL { get; set; }
        [Required]
        public bool IsActive { get; set; }
        
    }
}