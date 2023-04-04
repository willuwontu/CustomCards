using System.Collections.Generic;
using UnityEngine;

namespace R3DCore
{
    public class CustomCard_AddToProjectile : ScriptableObject, IFireProjectile
    {
        public void FireProjectile(Projectile projectile, Player player, int stacks)
        {
            for (int i = 0; i < this.toAdd.Count; i++)
            {
                this.toAdd[i].AddToProjectile(projectile, player, stacks);
            }
        }

        public List<ProjectileAdds> toAdd;
    }
}
