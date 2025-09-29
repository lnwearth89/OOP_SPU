using System;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public string skillName;
    public float cooldownTime;
    public float lastUsedTime = float.MinValue; // ��������ش�����ʡ��

    public GameObject skillEffect;

    // ���ʹ����� abstract, �ѧ�Ѻ�������١��ͧ implement
    public abstract void Activate(Character character);
    public void ResetCooldown()
    {
        lastUsedTime = float.MinValue; // ��������ش�����ʡ��
    }   
    public bool IsReady()
    {
        return Time.time >= lastUsedTime + cooldownTime;
    }

    // ���ʹ����Ѻ�ѹ�֡���ҷ����ʡ��
    public void TimeStampSkill()
    {
        lastUsedTime = Time.time;
    }

    // ���ʹ����ա����ҹ�����ѹ
    public void DisplayInfo()
    {
        Debug.Log($"Skill: {skillName}");
        Debug.Log($"Cooldown: {cooldownTime}s");
    }
}
