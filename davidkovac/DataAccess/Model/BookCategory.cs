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
    /// Třída book category slouží k vytvoření žánrů knihy
    /// </summary>
    public class BookCategory : IEntity
    {
        /// <summary>
        /// Identifikační číslo žánru, tvořeno v databázy
        /// </summary>
        public virtual int Id { get; set; }
        
        /// <summary>
        /// Popis žánru
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Description"),
        Required(ErrorMessageResourceType = typeof (Resource), ErrorMessageResourceName = "RequiredDBC"),
        MaxLength(10, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtDBCMax")]
        public virtual string Description { get; set; }
        
        /// <summary>
        /// Název žánru
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Name"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredNBC"),
        MaxLength(50, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtNBCMax")]
        public virtual string Name { get; set; }
    }
}
