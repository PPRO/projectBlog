using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;
using DataAccess.Interface;

namespace DataAccess.Model
{
    /// <summary>
    /// Třída book slouží k vytvoření knihy
    /// </summary>
    public class Book : IEntity
    {
        /// <summary>
        /// Identifikační číslo knihy, tvořeno v databázy
        /// </summary>
        public virtual int Id { get; set; }
       
        /// <summary>
        /// Popis knihy
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Description"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "Description"),
        MaxLength(500, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtDB")]
        public virtual string Description { get; set; }
        
        /// <summary>
        /// Název knihy
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "TitleB"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredTB"),
        MaxLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtTB")]
        public virtual string Title { get; set; }

        /// <summary>
        /// Meta tag description, který je generován pro každý článek v blogu
        /// </summary>
        
        [Display(ResourceType = typeof(Resource), Name = "Metadata"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredM"),
        MaxLength(200, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtM")]
        public virtual string Metadata { get; set; }

        /// <summary>
        /// Meta tag keywords, který je generován pro každý článek v blogu
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Keywords"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredK"),
        MaxLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtK")]
        public virtual string Keywords { get; set; }

        /// <summary>
        /// Obrázek knihy
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Image")]
        public virtual string ImageName { get; set; }

        /// <summary>
        /// Datum vložení
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "PosteDate")]
        public virtual DateTime PosteDate { get; set; }

        /// <summary>
        /// Autor knihy
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Author"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredAuthor")]
        public virtual Author Author { get; set; }

        /// <summary>
        /// Žánr knihy
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "BCName"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredCB")]
        public virtual BookCategory Category { get; set; }
    }
}
