using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
	public class BlogRole : IEntity
	{
		public virtual string Description { get; set; }

		public virtual string Identificator { get; set; }

		public virtual int Id { get; set; }
	}
}
