using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace DataAccess.Model
{
	public class BlogUser : MembershipUser, IEntity
	{
		public virtual int Id { get; set; }

		[Required(ErrorMessage = "Jméno je povinné")]
		public virtual string Name { get; set; }

		[Required(ErrorMessage = "Příjmení je povinné")]
		public virtual string Surname { get; set; }

		[Required(ErrorMessage = "Login je povinný")]
		public virtual string Login { get; set; }

		[Required(ErrorMessage = "Email je povinné")]
		[EmailAddress]
		public virtual string Mail { get; set; }

		[Required(ErrorMessage = "Heslo je povinné")]
		[MinLength(5)]
		public virtual string Password { get; set; }

		public virtual bool Active { get; set; }

		public virtual BlogRole Role { get; set; }
	}
}
