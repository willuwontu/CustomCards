using HarmonyLib;
using System;

namespace R3DCore.CCAPI.Patches
{
    [HarmonyPatch(typeof(Player))]
    class Player_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        static void Awake(Player __instance)
        {
            var cardHandler = __instance.gameObject.GetOrAddComponent<PL_CustomStatHandler>();
        }
    }
}