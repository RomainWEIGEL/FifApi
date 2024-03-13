using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("album")]
    public class Album
    {
        private int idAlbum;
        private string nomAlbum;

        public Album(int idAlbum, string nomAlbum)
        {
            this.idAlbum = idAlbum;
            this.nomAlbum = nomAlbum;
        }

        [Key]
        [Column("idalbum", TypeName = "int")]
        public int IdAlbum
        {
            get
            {
                return idAlbum;
            }

            set
            {
                idAlbum = value;
            }
        }

        [Column("nomalbum", TypeName = "varchar(100)")]
        public string NomAlbum
        {
            get
            {
                return this.nomAlbum;
            }

            set
            {
                this.nomAlbum = value;
            }
        }

        [InverseProperty("AlbumDuProduit")]
        public virtual ICollection<Produit> ProduitAlbum { get; set; }
    }
}
