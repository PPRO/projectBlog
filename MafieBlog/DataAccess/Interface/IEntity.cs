using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Interface
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
