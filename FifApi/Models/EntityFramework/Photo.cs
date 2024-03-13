using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("photo")]
    public class Photo
    {
        private int idPhoto;
        private string urlPhoto;
    }
}
