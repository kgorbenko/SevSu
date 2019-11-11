using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{

    //Interface to enable examing objects of Train struct
    //and class as different implementation of same logic
    public interface ITrain
    {
        string Destination { get; set; }

        int Number { get; }

        DateTime Departure { get; }
    }
}
