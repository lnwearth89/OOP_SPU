using System;
using UnityEngine;

[CreateAssetMenu(fileName = "FireballSkill", menuName = "Skills/FireballSkill")]
public class FireballSkill : Skill
{
    public float searchRadius = 5;

    public FireballSkill()
    {
        this.skillName = "Fireball";
        this.cooldownTime = 5f;
    }

    // ต้อง Override เมธอด Activate() ตามที่ Abstract Class กำหนด
    public override void Activate(Character character)
    {
        Debug.Log(character.Name +" Casting Fireball! Deals 50 damage.");
        GameObject g = Instantiate(skillEffect, character.transform.position, Quaternion.identity, character.transform);
        Destroy(g, 1);
        character.TakeDamage(20);
        Enemy target = (Enemy)FindNearestEnemy(character);
        if (target != null)
        {
            target.TakeDamage(50);
            Debug.Log($"{character.Name} casts {skillName} on {target.Name}, dealing 50 damage!");
        }
        else
        {
            Debug.Log("No enemies in range to target with Fireball.");
        }
        // โค้ดที่ใช้ในการสร้างลูกไฟและคำนวณความเสียหาย
    }
    // A private helper method to find the nearest enemy
    private Character FindNearestEnemy(Character caster)
    {
        // Find all colliders within the search radius
        Collider[] hitColliders = Physics.OverlapSphere(caster.transform.position, searchRadius);
        Enemy nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            // Check if the collider belongs to a character that isn't the caster
            Enemy targetCharacter = hitCollider.GetComponent<Enemy>();
            if (targetCharacter != null && targetCharacter != caster)
            {
                // Calculate the distance and check if it's the closest so far
                float distanceToTarget = Vector3.Distance(caster.transform.position, targetCharacter.transform.position);
                if (distanceToTarget < shortestDistance)
                {
                    shortestDistance = distanceToTarget;
                    nearestEnemy = targetCharacter;
                }
            }
        }
        return nearestEnemy;
    }
}
