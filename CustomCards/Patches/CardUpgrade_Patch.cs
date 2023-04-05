using HarmonyLib;
using System;
using UnityEngine;

namespace R3DCore.CCAPI.Patches
{
    [HarmonyPatch(typeof(CardUpgrade))]
    class CardUpgrade_Patch
    {
        [HarmonyPostfix]
        [HarmonyPatch("ProjectileHit")]
        static void ProjectileHit(CardUpgrade __instance, ProjectileHitData hit, Player player, int stacks)
        {
            if (__instance is CustomCardUpgrade customCardUpgrade)
            {
                foreach (IProjectileHit applyToPlayer in customCardUpgrade.projectileHits)
                {
                    try
                    {
                        applyToPlayer.ProjectileHit(hit, player, stacks);
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogError($"Exception thrown by '[{customCardUpgrade.modname}] - {customCardUpgrade.cardname}' on projectile hit, see error log below.");
                        UnityEngine.Debug.LogException(e);
                    }
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("FireProjectile")]
        static void FireProjectile(CardUpgrade __instance, Projectile projectile, Player player, int stacks)
        {
            if (__instance is CustomCardUpgrade customCardUpgrade)
            {
                foreach (IFireProjectile applyToPlayer in customCardUpgrade.fireProjectiles)
                {
                    try
                    {
                        applyToPlayer.FireProjectile(projectile, player, stacks);
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogError($"Exception thrown by '[{customCardUpgrade.modname}] - {customCardUpgrade.cardname}' when firing projectile, see error log below.");
                        UnityEngine.Debug.LogException(e);
                    }
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch("ApplyToPlayer")]
        static void ApplyToPlayer(CardUpgrade __instance, Player player)
        {
            if (__instance is CustomCardUpgrade customCardUpgrade)
            {
                player.stats.AddStats(customCardUpgrade.stats);

                var customHandler = player.gameObject.GetOrAddComponent<PL_CustomStatHandler>();

                foreach (var kvp  in customCardUpgrade.customStats)
                {
                    if (customHandler.customStats.ContainsKey(kvp.Key))
                    {
                        customHandler.customStats[kvp.Key].AddStat(kvp.Value);
                    }
                    else
                    {
                        customHandler.customStats[kvp.Key] = new PlayerStatsEntry();
                        customHandler.customStats[kvp.Key].AddStat(kvp.Value);
                    }
                }

                foreach (IApplyToPlayer applyToPlayer in customCardUpgrade.applyToPlayers)
                {
                    try
                    {
                        applyToPlayer.ApplyToPlayer(player);
                    }
                    catch (Exception e)
                    {
                        UnityEngine.Debug.LogError($"Exception thrown by '[{customCardUpgrade.modname}] - {customCardUpgrade.cardname}' when applying to player, see error log below.");
                        UnityEngine.Debug.LogException(e);
                    }
                }
            }
        }

        //[HarmonyPrefix]
        //[HarmonyPatch("SomeMethod")]
        //static void MyMethodName()
        //{

        //}

        //[HarmonyPostfix]
        //[HarmonyPatch("SomeMethod")]
        //static void MyMethodName()
        //{

        //}
    }
}