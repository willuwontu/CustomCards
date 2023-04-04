using HarmonyLib;
using System;
using UnityEngine;
using R3DCore.CM;

namespace R3DCore.CCAPI.Patches
{
    [HarmonyPatch(typeof(CardManager))]
    class CardManager_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(CardManager.OnCardReappliedToPlayer))]
        static void OnCardReappliedToPlayer(Player player, CardUpgrade card)
        {
            if (card is CustomCardUpgrade customCardUpgrade)
            {
                foreach (IOnReapplyToPlayer applyToPlayer in customCardUpgrade.projectileHits)
                {
                    try
                    {
                        applyToPlayer.OnReapplyToPlayer(player);
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogError($"Exception thrown by '[{customCardUpgrade.modname}] - {customCardUpgrade.cardname}' on reapplying card, see error log below.");
                        UnityEngine.Debug.LogException(e);
                    }
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(CardManager.OnCardRemovedFromPlayer))]
        static void OnCardRemovedFromPlayer(Player player, CardUpgrade card)
        {
            if (card is CustomCardUpgrade customCardUpgrade)
            {
                foreach (IOnReapplyToPlayer applyToPlayer in customCardUpgrade.projectileHits)
                {
                    try
                    {
                        applyToPlayer.OnReapplyToPlayer(player);
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogError($"Exception thrown by '[{customCardUpgrade.modname}] - {customCardUpgrade.cardname}' on removing card, see error log below.");
                        UnityEngine.Debug.LogException(e);
                    }
                }
            }
        }
    }
}