using UnityEngine;

public enum ModifierType
{
    Player, // stats modifiers, debuffs, buffs
    Enemy, // enemy stats modifiers, debuffs, buffs
    Environment, // dungeon size, loot quality
    Base, // Base game modifiers like difficulty
    Default // default modifier
}

[CreateAssetMenu(fileName = "ModifierObject", menuName = "Modifiers/ModifierObject")]
public class Modifier : ScriptableObject
{
    public ModifierType modifierType = ModifierType.Default;
    public virtual void ApplyModifier() {}
}
