using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;
using Microsoft.Win32;
using Resources;

namespace DataAccess.Model
{
    /// <summary>
    /// Třída slouží k vytvoření autora knihy
    /// </summary>
    public class Author : IEntity, IPerson
    {
        /// <summary>
        /// Identifikační číslo autora, tvořeno v databázy
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Jméno autora
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "PersonName"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredPN")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Příjmení autora
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "PersonSurname"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredPS")]
        public virtual string Surname { get; set; }

        /// <summary>
        /// Prostřední jméno autora
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "PersonMiddleName")]
        public virtual string MiddleName { get; set; }
    }
}
