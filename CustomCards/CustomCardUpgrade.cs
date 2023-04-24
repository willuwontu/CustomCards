using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using R3DCore;
using UnityEngine;

namespace R3DCore
{
    public class CustomCardUpgrade : CardUpgrade
    {
        #region CardInfo stuff
        // Information used for registering the card.

        public string cardname = "Lame Default Name";
        public string modname = "Modded";
        public int weight = 1;
        public bool hidden = false;
        public bool canBeReassigned = true;
        public bool allowMultiple = true;

        public CardCategory[] cardCategories = new CardCategory[0];
        public CardCategory[] blacklistedCategories = new CardCategory[0];

        public UnityEvent<CardInfo> buildEvent = new UnityEvent<CardInfo>();

        public CardInfo cardInfo;

        public void Register()
        {
            this.cardInfo = CardManager.RegisterCard(this.cardname, this, modname, this.weight, this.canBeReassigned, this.hidden, this.allowMultiple);

            this.cardInfo.categories = this.cardCategories;
            this.cardInfo.blacklistedCategories = this.blacklistedCategories;

            buildEvent?.Invoke(cardInfo);
        }

        public virtual void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        #endregion CardInfo stuff

        private static GameObject _defaultGameObject;

        internal static GameObject DefaultGameObject
        {
            get 
            { 
                if (_defaultGameObject == null)
                {
                    _defaultGameObject = new GameObject("CustomCardUpgradeHolder");
                    DontDestroyOnLoad(_defaultGameObject);
                }
                return _defaultGameObject; 
            }
        }

        public static CustomCardUpgrade NewCustomCard()
        {
            return DefaultGameObject.AddComponent<CustomCardUpgrade>();
        }

        public static CustomCardUpgrade NewCustomCard(GameObject gameObject)
        {
            return gameObject.AddComponent<CustomCardUpgrade>();
        }

        public List<IApplyToPlayer> applyToPlayers = new List<IApplyToPlayer>();
        public List<IFireProjectile> fireProjectiles = new List<IFireProjectile>();
        public List<IProjectileHit> projectileHits = new List<IProjectileHit>();
        public List<IOnReapplyToPlayer> onReapplyToPlayers = new List<IOnReapplyToPlayer>();
        public List<IOnRemoveFromPlayer> onRemoveFromPlayers = new List<IOnRemoveFromPlayer>();

        public PlayerStats stats = new PlayerStats() { Health = new PlayerStatsEntry(),
            LifeSteal = new PlayerStatsEntry(),
            Spread = new PlayerStatsEntry(),
            Speed = new PlayerStatsEntry(),
            AbilityCooldown = new PlayerStatsEntry(),
            ReloadSpeed = new PlayerStatsEntry(),
            Ammo = new PlayerStatsEntry(),
            NrOfProjectiles = new PlayerStatsEntry(),
            Damage = new PlayerStatsEntry(),
            ProjectileSpeed = new PlayerStatsEntry(),
            ProjectileBounces = new PlayerStatsEntry(),
            FireRate = new PlayerStatsEntry(),
        };
        public Dictionary<string, PlayerStatsEntry> customStats = new Dictionary<string, PlayerStatsEntry>();
    }
}
