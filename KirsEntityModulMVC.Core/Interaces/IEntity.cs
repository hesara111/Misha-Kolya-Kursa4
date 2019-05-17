using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirsEntityModulMVC.Core.Interaces
{
    public interface IEntity<TId>where TId:class
    {
        TId Id { get; set; }
    }
}
