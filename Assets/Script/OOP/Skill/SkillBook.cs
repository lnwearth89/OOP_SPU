using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillBook : MonoBehaviour
{
    public List<Skill> skillsSet = new List<Skill>();
    public List<IDurationSkill> activeSkills = new List<IDurationSkill>();

    Player player;
    public void Start()
    {
        // เพิ่มสกิลต่างๆ เข้าไปใน List
        player = GetComponent<Player>();
        foreach (var skill in skillsSet)
        {
            skill.ResetCooldown();
        }
        //skillsSet.Add(new FireballSkill());
        //skillsSet.Add(new HealSkill());
        //skillsSet.Add(new BuffSkillMoveSpeed());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseSkill(0); // ใช้สกิลที่ 1 (Fireball)
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseSkill(1); // ใช้สกิลที่ 2 (Heal)
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseSkill(2); // ใช้สกิลที่ 3 (Buff Move Speed)
        }
        // อัปเดตสกิลที่มีผลต่อเนื่อง
        for (int i = activeSkills.Count - 1; i >= 0; i--)
        {
            activeSkills[i].UpdateSkill(player);
            if (activeSkills[i].timer <= 0)
            {
                activeSkills.RemoveAt(i);
            }
        }
    }

    public void UseSkill(int index)
    {
        if (index >= 0 && index < skillsSet.Count)
        {
            Skill skill = skillsSet[index];
            if (!skill.IsReady())
            {
                Debug.Log($"Skill '{skill.skillName}' is on cooldown. Time remaining: {skill.lastUsedTime + skill.cooldownTime - Time.time:F2}s");
                return; // จบการทำงานถ้าสกิลติดคูลดาวน์
            }
            skill.Activate(player);
            skill.TimeStampSkill(); // บันทึกเวลาที่ใช้สกิล
            // ตรวจสอบว่าเป็นสกิลที่มีผลต่อเนื่องหรือไม่
            if (skill is IDurationSkill activeSkill)
            {
                activeSkills.Add(activeSkill);
            }
        }
    }
    private void OnDrawGizmos()
    {
        
            // Set the gizmo color
            Gizmos.color = Color.yellow;
            // Draw a wire sphere at the player's position with the fireball's search radius
            Gizmos.DrawWireSphere(transform.position, 5);
        
    }
}
