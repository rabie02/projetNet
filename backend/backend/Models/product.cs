//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace backend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public int id_product { get; set; }
        public string nom_produit { get; set; }
        public double prix { get; set; }

        public string photo { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string type { get; set; }
    }
}