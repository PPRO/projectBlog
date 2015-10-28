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
    /// Třída role slouží k vytvoření role uživatele
    /// </summary>
    public class Role: IEntity
    {
        /// <summary>
        /// Identifikační číslo role, je tvořeno automaticky v databázy
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Popis role
        /// </summary>
        [Display(Name = "Description", ResourceType = typeof(Resource)),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredDR"),
        MaxLength(10, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtRDMax")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Název role
        /// </summary>
        [Display(Name = "RoleName", ResourceType = typeof(Resource)),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredRN"),
        MaxLength(10, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtRNMax")]
        public virtual string Name { get; set; }
    }
}
