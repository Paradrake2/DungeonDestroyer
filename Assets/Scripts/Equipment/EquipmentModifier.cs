using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentModifier", menuName = "Modifiers/EquipmentModifier")]
public class EquipmentModifier : ScriptableObject
{
    public string modifierName;
    public Modifier modifier;
    public int minValue;
    public int maxValue;

    public void SetModifierValues(int min, int max)
    {
        minValue = min;
        maxValue = max;
    }

    public float GetModifierValue(float mult)
    {
        return Random.Range(minValue, maxValue + 1) * mult;
    }
}
