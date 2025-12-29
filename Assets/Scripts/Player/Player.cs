using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStats stats;
    public PlayerCombat combat;
    public List<AdvancedPlayerStat> dungeonAdvancedStats; // dungeon advanced stats, changed during dungeon runs, cleared after death

    public Equipment[] baseEquipment;
    public Equipment[] equippedEquipment;

    public float dungeonHealth; // Set when dungeon starts
    public float dungeonDamage; // Set when dungeon starts
    public float dungeonDefense; // Set when dungeon starts
    public float dungeonAttackSpeed; // Set when dungeon starts
    public float dungeonMoveSpeed; // Set when dungeon starts
    public float currentHealth; // Changes during dungeon
    public int level;
    public float currentXP;
    public float xpToNextLevel;
    public float baseXPToNextLevel = 100f;
    public int goldAmount; // gold collected during dungeon run

    void Start()
    {
        if (stats == null)
        {
            stats = PlayerStats.instance;
        }
        if (combat == null)
        {
            combat = GetComponent<PlayerCombat>();
        }
        StartDungeonStats();
    }
    public void GainXP(float amount)
    {
        currentXP += amount * (1 + stats.GetAdvancedStatValue("XPMultiplier"));
        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }
    }
    public void LevelUp()
    {
        level++;
        // Increase stats on level up
        dungeonHealth += 10f;
        dungeonDamage += 2f;
        dungeonDefense += 1f;
        currentHealth = dungeonHealth;
        xpToNextLevel *= 1.2f; // Increase XP needed for next level
        // modifier selection pop up
    }
    public float GetAdvancedStatValue(string statName)
    {
        float total = 0f;
        foreach (AdvancedPlayerStat advStat in dungeonAdvancedStats)
        {
            if (advStat.statName == statName)
            {
                total += advStat.currentValue;
            }
        }
        foreach (AdvancedPlayerStat advStat in stats.persistentAdvancedStats)
        {
            if (advStat.statName == statName)
            {
                total += advStat.currentValue;
            }
        }
        return total;
    }
    public void StartDungeonStats()
    {
        stats.SetPlayer();
        level = 0;
        currentXP = 0f;
        xpToNextLevel = baseXPToNextLevel;
        dungeonHealth = stats.GetStatValue(PlayerStat.Health);
        dungeonDamage = stats.GetStatValue(PlayerStat.Damage);
        dungeonDefense = stats.GetStatValue(PlayerStat.Defense);
        dungeonAttackSpeed = stats.GetStatValue(PlayerStat.AttackSpeed);
        dungeonMoveSpeed = stats.GetStatValue(PlayerStat.MoveSpeed);
        currentHealth = dungeonHealth;
    }
    public void AddAdvancedStat(string statName, float baseValue)
    {
        // Check if stat already exists in dungeon stats
        foreach (AdvancedPlayerStat advStat in dungeonAdvancedStats)
        {
            if (advStat.statName == statName)
            {
                advStat.currentValue += baseValue;
                return;
            }
        }
        // If not found, add new advanced stat
        AdvancedPlayerStat newStat = new AdvancedPlayerStat
        {
            statName = statName,
            baseValue = baseValue,
            currentValue = baseValue
        };
        dungeonAdvancedStats.Add(newStat);
    }
    public void ModifyStat(PlayerStat stat, float amount)
    {
        switch (stat)
        {
            case PlayerStat.Health:
                dungeonHealth += amount;
                currentHealth += amount;
                if (currentHealth > dungeonHealth)
                {
                    currentHealth = dungeonHealth;
                }
                break;
            case PlayerStat.Damage:
                dungeonDamage += amount;
                break;
            case PlayerStat.Defense:
                dungeonDefense += amount;
                break;
            case PlayerStat.AttackSpeed:
                dungeonAttackSpeed += amount;
                break;
            case PlayerStat.MoveSpeed:
                dungeonMoveSpeed += amount;
                break;
        }
    }
    public void ApplyEquipmentStats()
    {
        
    }
    public void ApplyModifiers()
    {
        foreach (Modifier mod in ModifierManager.instance.activeModifiers)
        {
            if (mod.modifierType == ModifierType.Player) mod.ApplyModifier();
        }
    }
    public void ClearDungeonStats()
    {
        dungeonAdvancedStats.Clear();
    }

    public void TakeDamage(float damage)
    {
        float effectiveDamage = damage - dungeonDefense;
        if (effectiveDamage < 0) effectiveDamage = 0;
        currentHealth -= effectiveDamage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Die()
    {
        ModifierManager.instance.ClearTypeModifiers(ModifierType.Player);
        ClearDungeonStats();
        // ClearEquipment();
        stats.ClearPlayer();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeybindManager.instance.attackKey))
        {
            combat.FireProjectile(targetPosition: Camera.main.ScreenToWorldPoint(Input.mousePosition), 10, 10);
            Debug.Log("Attack fired");
        }
    }
}
