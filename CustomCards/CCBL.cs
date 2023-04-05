using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace R3DCore
{
    [BepInDependency("com.willuwontu.rounds3d.cardmanager")]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("ROUNDS 3D.exe")]
    internal class CCBL : BaseUnityPlugin
    {
        private const string ModId = "com.willuwontu.rounds3d.customcard";
        private const string ModName = "Custom Card API";
        public const string Version = "0.0.0";

        public static CCBL instance { get; private set; }

        void Awake()
        {
            instance = this;

            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
#if DEBUG
            var glassCannongo = new GameObject("Glass Cannon", typeof(CustomCardUpgrade));
            var glassCannon = glassCannongo.GetComponent<CustomCardUpgrade>();
            DontDestroyOnLoad(glassCannon.gameObject);

            glassCannon.cardname = "Glass Cannon";
            glassCannon.modname = "CCAPI";
            glassCannon.weight = 5;
            glassCannon.stats.Health.multiplier = 0.5f;
            glassCannon.stats.Damage.multiplier = 2;
            glassCannon.stats.Speed.multiplier = 1.1f;
            glassCannon.customStats.Add("Jump Height", new PlayerStatsEntry() { multiplier = 1.5f });

            glassCannon.Register();
#endif
        }
    }
}
