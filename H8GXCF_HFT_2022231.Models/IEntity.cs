using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Models
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
