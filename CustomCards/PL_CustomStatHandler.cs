using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace R3DCore
{
    internal class PL_CustomStatHandler : MonoBehaviour
    {
        public Dictionary<string, PlayerStatsEntry> customStats = new Dictionary<string, PlayerStatsEntry>();
    }
}
