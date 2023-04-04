using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using R3DCore;

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

        public void Register()
        {
            var cardInfo = CardManager.RegisterCard(this.cardname, this, modname, this.weight, this.canBeReassigned, this.hidden, this.allowMultiple);

            cardInfo.categories = this.cardCategories;
            cardInfo.blacklistedCategories = this.blacklistedCategories;

            buildEvent?.Invoke(cardInfo);
        }

        #endregion CardInfo stuff

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
            ProjectileBounces = new PlayerStatsEntry()
        };
        public Dictionary<string, PlayerStatsEntry> customStats = new Dictionary<string, PlayerStatsEntry>();
    }
}
