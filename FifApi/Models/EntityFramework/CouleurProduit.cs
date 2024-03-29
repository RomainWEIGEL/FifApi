﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FifApi.Models.EntityFramework
{
    [Table("couleurproduit")]
    public class CouleurProduit
    {
        private int idCouleurProduit;
        private int produitId;
        private int couleurId;
        private double prix;
        private string codeBarre;

        public CouleurProduit(double prix, string codeBarre, int produitId, int couleurId)
        {
            this.prix = prix;
            this.codeBarre = codeBarre;
            this.ProduitId = produitId;
            this.CouleurId = couleurId;
        }

        
        [Column("prix", TypeName = "decimal(8,2)")]
        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        [Column("codebarre", TypeName = "varchar(48)")]
        public string CodeBarre
        {
            get { return codeBarre; }
            set { codeBarre = value; }
        }

        
        [Column("produitid", TypeName = "int")]
        public int ProduitId
        {
            get
            {
                return produitId;
            }

            set
            {
                produitId = value;
            }
        }

        
        [Column("couleurid", TypeName = "int")]
        public int CouleurId
        {
            get
            {
                return this.couleurId;
            }

            set
            {
                this.couleurId = value;
            }
        }

        [Key]
        [Column("idcouleurproduit", TypeName = "int")]
        public int IdCouleurProduit
        {
            get
            {
                return this.idCouleurProduit;
            }
            set
            {
                this.idCouleurProduit = value;
            }
        }

        [ForeignKey("ProduitId")]
        [InverseProperty("ColoriationDuProduit")]
        public virtual Produit ProduitAvecCouleur { get; set; }
        [ForeignKey("MatchId")]
        [InverseProperty("ColoriationDuProduit")]
        public virtual Couleur CouleurDuProduit { get; set; }


        [InverseProperty("ProduitEnTaille")]
        public virtual ICollection<Stock> StockDuProduit { get; set; }

       
    }
}
