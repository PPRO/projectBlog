using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ArticleCategory : IEntity
    {
        public virtual int Id { get; set; }

		public virtual string Identificator { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
    }
}
