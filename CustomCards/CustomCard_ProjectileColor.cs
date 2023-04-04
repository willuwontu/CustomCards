using System.Collections.Generic;
using UnityEngine;

namespace R3DCore
{
    public class CustomCard_ProjectileColor : ScriptableObject, IFireProjectile
    {
        public void FireProjectile(Projectile projectile, Player player, int stacks)
        {
            SpawnedObject component = projectile.GetComponent<SpawnedObject>();
            if (component.color == Color.black)
            {
                component.color = this.color;
                return;
            }
            float num = 1f;
            float num2 = 1f;
            float num3 = 1f;
            float b = 1f;
            float b2 = 1f;
            float b3 = 1f;
            Color.RGBToHSV(component.color, out num, out num2, out num3);
            Color.RGBToHSV(this.color, out b, out b2, out b3);
            num = Mathf.Lerp(num, b, 0.5f);
            num2 = Mathf.Lerp(num2, b2, 0.5f);
            num3 = Mathf.Lerp(num3, b3, 0.5f);
            component.color = Color.HSVToRGB(num, num2, num3);
        }

        public Color color;
    }
}
