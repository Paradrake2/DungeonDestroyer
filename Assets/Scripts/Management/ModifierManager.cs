using System.Collections.Generic;
using UnityEngine;

public class ModifierManager : MonoBehaviour
{
    public static ModifierManager instance;
    public List<Modifier> activeModifiers = new List<Modifier>();
    public void AddModifier(Modifier modifier)
    {
        activeModifiers.Add(modifier);
    }
    public void RemoveModifier(Modifier modifier)
    {
        activeModifiers.Remove(modifier);
    }
    public void ClearTypeModifiers(ModifierType type)
    {
        foreach (Modifier modifier in activeModifiers)
        {
            if (modifier.modifierType == type)
            {
                activeModifiers.Remove(modifier);
            }
        }
    }
    public void ClearAllModifiers()
    {
        activeModifiers.Clear();
    }
    public void ApplyAllModifiers()
    {
        foreach (Modifier modifier in activeModifiers)
        {
            modifier.ApplyModifier();
        }
    }
    public void ApplyModifiersOfType(ModifierType type)
    {
        foreach (Modifier modifier in activeModifiers)
        {
            if (modifier.modifierType == type)
            {
                modifier.ApplyModifier();
            }
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
