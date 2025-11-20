using UnityEngine;

[CreateAssetMenu(menuName = "Unit/UnitClassData")]
public class UnitClassData : ScriptableObject
{
    public enum unitClass
    {
        Warrior,
        Archer,
        Tank,
        Mage,
        Healer
    }
    public unitClass unitclass;

    public int Power;
    public int Mana;
    public int Health;
    public float Speed;
    public int AttakRange;
    public int AttackSpeed;
}
