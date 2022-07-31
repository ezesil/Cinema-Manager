using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.CustomFlags
{
    public class VisibleOnGrid : Attribute
    {
        public string Name { get; set; } = "";

        public VisibleOnGrid()
        {

        }

        public VisibleOnGrid(string name)
        {
            Name = name;
        }
    }
}
