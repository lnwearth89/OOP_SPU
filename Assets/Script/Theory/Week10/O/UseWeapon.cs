using Theory.Week10;
using UnityEngine;


public class UseWeapon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("---- Bad Calculate Damage ----");
        Weapon sword = new Weapon(WeaponType.Sword, 10);
        Debug.Log($"Sword Damage: {BadCalculateDamage(sword)}"); // Output: Sword Damage: 15

        Debug.Log("---- Good Calculate Damage ----");
        IBonusWeapon bow = new Bow();
        Debug.Log($"Bow Damage: {GoodCalculateDamage(bow)}"); // Output: Bow Damage: 9
    }
    public int GoodCalculateDamage(IBonusWeapon weapon)
    {
        return weapon.GetDamage(); // ���¡�����ʹ�ҡ Interface �µç
    }

    public int BadCalculateDamage(Weapon weapon)
    {
        int totalDamage = weapon.BaseDamage;
        if (weapon.Type == WeaponType.Sword)
        {
            totalDamage += 5; // ⺹�ʴҺ
        }
        else if (weapon.Type == WeaponType.Bow)
        {
            totalDamage += 3; // ⺹�ʸ��
        }
        else if (weapon.Type == WeaponType.Gun)
        {
            totalDamage += 10; // ⺹�ʻ׹
        }
        // ������� WeaponType.Axe ��ͧ������ else if �ç���
        return totalDamage;
    }
    
}
