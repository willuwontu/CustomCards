using BepInEx;
using HarmonyLib;

namespace R3DCore
{
    [BepInDependency("com.willis.rounds.unbound")]
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

        }
    }
}
