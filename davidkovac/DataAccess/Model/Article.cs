using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccess.Interface;
using Resources;

namespace DataAccess.Model
{
    /// <summary>
    /// Třída slouží k vytvoření článku
    /// </summary>
    public class Article : IEntity
    {
        /// <summary>
        /// Identifikační číslo článku, tvořeno v databázy
        /// </summary>
        public virtual int Id { get; set; }
       
        /// <summary>
        /// Název článku
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "TitleA"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredAT"),
        MaxLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtAT")]
        public virtual string Title { get; set; }

        /// <summary>
        /// Popis článku
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Description"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredDA"),
        MaxLength(500, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtDA"),
        AllowHtml]
        public virtual string Description { get; set; }

        /// <summary>
        /// Meta tag description, který je generován ke každému článku v blogu
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Metadata"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredM"),
        MaxLength(200, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtM")]
        public virtual string Metadata { get; set; }
        
        /// <summary>
        /// Text článku
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "TextA"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredAText"),
        AllowHtml]
        public virtual string Text { get; set; }

        /// <summary>
        /// Meta tag keywords, který je generován ke každému článku v blogu
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Keywords"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredK"),
        MaxLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtK")]
        public virtual string Keywords { get; set; }

        /// <summary>
        /// Obrázek
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "ImageName")]
        public virtual string ImageName { get; set; }

        /// <summary>
        /// Datum přidání článku
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "PosteDate")]
        public virtual DateTime PosteDate { get; set; }
        
        /// <summary>
        /// Jméno autora článku
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Kategorie článku
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Category")]
        public virtual ArticleCategory Category { get; set; }
    }
}
