using UnityEngine;

[CreateAssetMenu(menuName = "Unit/AttackData")]
public class AttackData : ScriptableObject
{
    [Header("Attacks")]
    public float AttackRange;
    public float AttackSpeed;
    public float AttackDamage;

    [Header("Skills")]
    public string SkillName;
    public float SkillDamage = 3f;
    public float SkillCoolTime = 10f;
    public float SkillRange;
}
