using UnityEngine;

namespace Theory.Week10
{
    public class Axe : IBonusWeapon
    {
        public int Damage = 15;
        public int GetDamage()
        {
            return Damage + 10;
        }
    }

}

