using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccess.Model
{
	public class BlogComment : IEntity
	{
		public virtual int Id { get; set; }

		[Required(ErrorMessage = "Musíte vyplnit své jméno")]
		
		public virtual string Name { get; set; }

		[Required( ErrorMessage = "Musíte vyplnit email" )]
		[EmailAddress]
		[StringLength(50)]
		public virtual string Email { get; set; }

		public virtual DateTime CommentDate { get; set; }

		[Required( ErrorMessage = "Musíte vyplnit komentář" )]
		[MaxLength(500)]
		[AllowHtml]
		public virtual string Comment { get; set; }

		public virtual Article Article { get; set; }

	}
}
