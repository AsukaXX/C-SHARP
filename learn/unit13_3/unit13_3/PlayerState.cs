using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit13_3
{
    [Serializable]
    public enum PlayerState
    {
        Inactive,
        Active,
        MustDiscard,
        Winner,
        Loser
    }
}
