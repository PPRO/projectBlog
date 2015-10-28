using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    /// <summary>
    /// Rozhraní osoba
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Jméno osoby
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Příjmení osoby
        /// </summary>
        string Surname { get; set; }
    }
}
