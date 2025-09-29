using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffSkillMoveSpeed", menuName = "Skills/BuffSkillMoveSpeed")]
public class BuffSkillMoveSpeed : Skill, IDurationSkill
{
    float SpeedIncreaseAmount = 5f; // จำนวนที่เพิ่มความเร็ว
    float OriginalSpeed; // ความเร็วเดิมของตัวละคร
    float TargetSpeed;
    public float Duration { get; set; }
    public float timer { get; set; }
    public BuffSkillMoveSpeed()
    {
        this.skillName = "Speed Boost";
        this.cooldownTime = 5;
        this.Duration = 2f; // ระยะเวลาที่สกิลมีผล
    }
    public override void Activate(Character character)
    {
        timer = Duration;
        GameObject g = Instantiate(skillEffect, character.transform.position, Quaternion.identity, character.transform);
        Destroy(g, 1);
        OriginalSpeed = character.movementSpeed;
        TargetSpeed = OriginalSpeed + SpeedIncreaseAmount;
        Debug.Log($"{character.Name} speed increased by {SpeedIncreaseAmount} for {Duration} seconds.");
    }

    public void Deactivate(Character character)
    {
        character.movementSpeed = OriginalSpeed;
        Debug.Log($"{character.Name}'s speed boost has ended.");
    }

    public void UpdateSkill(Character character)
    {
        timer -= Time.deltaTime;
        character.movementSpeed = TargetSpeed;
        if (timer <= 0)
        {
            Deactivate(character);
        }
    }
}
