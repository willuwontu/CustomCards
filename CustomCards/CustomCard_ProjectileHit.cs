using System.Collections.Generic;
using UnityEngine;
using R3DCore.CCAPI.Extensions;

namespace R3DCore
{
    public class CustomCard_ProjectileHit : ScriptableObject, IProjectileHit
    {
        public void ProjectileHit(ProjectileHitData hit, Player player, int stacks)
        {
            for (int i = 0; i < this.projectileSpawns.Count; i++)
            {
                GameObject gameObject = this.projectileSpawns[i].DoSpawn(hit);
                gameObject.transform.localScale = Vector3.one * gameObject.transform.localScale.x * Mathf.Lerp(1f, player.GetDamageMultiplier(), this.damageScaling);
                gameObject.transform.localScale *= Mathf.Lerp(1f, (float)stacks, this.stackScaling);
            }
        }

        public List<ProjectileSpawn> projectileSpawns;

        [Range(0f, 1f)]
        public float damageScaling = 0.5f;

        [Range(0f, 1f)]
        public float stackScaling = 0.75f;
    }
}
