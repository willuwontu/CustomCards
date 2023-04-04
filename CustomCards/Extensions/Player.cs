using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace R3DCore.CCAPI.Extensions
{
    public static class PlayerExtension
    {
        public static float GetDamageMultiplier(this Player player)
        {
            return (float)typeof(Player).InvokeMember("GetDamageMultiplier",
                BindingFlags.Instance | BindingFlags.InvokeMethod |
                BindingFlags.NonPublic, null, player, new object[] { });
        }
    }
}