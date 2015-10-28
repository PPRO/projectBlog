using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;
using Resources;

namespace DataAccess.Model
{
    /// <summary>
    /// Třída slouží k vytvoření kategorie článků
    /// </summary>
    public class ArticleCategory : IEntity
    {
        /// <summary>
        /// Identifikační číslo kategorie, tvořëno v databázy
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Popis kategorie
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Description"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredDAC"),
        MaxLength(50, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtDAC")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Název kategorie
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "TitleAC"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredACT"),
        MaxLength(10, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtACT")]
        public virtual string Name { get; set; }
    }
}
