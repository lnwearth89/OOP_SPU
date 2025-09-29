using System;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public string skillName;
    public float cooldownTime;
    public float lastUsedTime = float.MinValue; // เวลาล่าสุดที่ใช้สกิล

    public GameObject skillEffect;

    // เมธอดที่เป็น abstract, บังคับให้คลาสลูกต้อง implement
    public abstract void Activate(Character character);
    public void ResetCooldown()
    {
        lastUsedTime = float.MinValue; // เวลาล่าสุดที่ใช้สกิล
    }   
    public bool IsReady()
    {
        return Time.time >= lastUsedTime + cooldownTime;
    }

    // เมธอดสำหรับบันทึกเวลาที่ใช้สกิล
    public void TimeStampSkill()
    {
        lastUsedTime = Time.time;
    }

    // เมธอดที่มีการใช้งานร่วมกัน
    public void DisplayInfo()
    {
        Debug.Log($"Skill: {skillName}");
        Debug.Log($"Cooldown: {cooldownTime}s");
    }
}
