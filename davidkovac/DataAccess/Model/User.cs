using System.ComponentModel.DataAnnotations;
using DataAccess.Interface;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DataAccess.Model
{
    /// <summary>
    /// Třída uživatel slouží k vytvoření uživatele
    /// </summary>
    public class User : MembershipUser, IEntity, IPerson

    {
        /// <summary>
        /// Identifikační číslo uživatele, je tvořeno v databázy
        /// </summary>
        public virtual int Id { get; set; }
        
        /// <summary>
        /// Jméno uživatele
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "PersonName"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredPN")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Příjmení uživatele
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "PersonSurname"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredPS")]
        public virtual string Surname { get; set; }

        /// <summary>
        /// Přezdívka uživatele, login uživatele
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Nickname"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredNickaname")]
        public virtual string Login { get; set; }

        /// <summary>
        /// Email uživatele
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Email"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "WrongEmail")]
        public virtual string Mail { get; set; }

        /// <summary>
        /// Heslo uživatele
        /// </summary>
        [Display(ResourceType = typeof(Resource), Name = "Password"),
        Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredPass")]
        [MinLength(5, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LenghtPassMin")]
        public virtual string Password { get; set; }

        /// <summary>
        /// Role uživatele
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
