using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resources;

namespace DataAccess.Model
{
    public class Mail
    {
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredEmail"),
        EmailAddress(ErrorMessage = "Neplatný formát")]       
        public string From
            {
                get;
                set;
            }
            public string To
            {
                get;
                set;
            }
        
            public string Subject
            {
                get;
                set;
            }
        [Required(ErrorMessage = "Text zprávy je povinný!"),
        MaxLength(500, ErrorMessage = "Max. poveleno znaků je 500")]
            public string Body
            {
                get;
                set;
            }
        [Required(ErrorMessage = "Pole jméno je povinné"),
        MaxLength(50, ErrorMessage = "Max délka jména je 50 znaků")]
        public string Name { get; set; }
    }
}
