using System.ComponentModel.DataAnnotations;

namespace okko.uzblazorclient.Models
{
    public class WebImagesModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public byte[] Picture { get; set; }
    }
}
