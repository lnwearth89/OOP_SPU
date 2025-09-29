using UnityEngine;

public interface IDurationSkill
{
    float Duration { get; set; }
    float timer { get; set; }
    void UpdateSkill(Character character);
    void Deactivate(Character character);
}