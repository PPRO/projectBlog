using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using DataAccess.Interface;

namespace DataAccess.Model
{
    public class Article : IEntity
    {
        public const string Pozdrav = "Nazdar Vole";
        public const string Pozdrav1 = "Cus";
        public const string Pozdrav2 = "Nazdarek";


        public virtual int Id { get; set; }
       
        [Required (ErrorMessage = "Nazev článku je vyzadovan")]
        public virtual string Title { get; set; }

        [Required (ErrorMessage = "Text článku je vyžadován")]
		[AllowHtml]
        public virtual string Text { get; set; }

        public virtual DateTime PostDate { get; set; }
		
		[Required (ErrorMessage = "Popis je vyžadován")]
        [AllowHtml]
        public virtual string Description { get; set; }

		
        public virtual string ImageName { get; set; }

		public virtual int CountComment { get; set; }

        public virtual ArticleCategory Category { get; set; }

		public virtual BlogUser User { get; set; }

        
    }
}