using System.Collections.Generic;
using UnityEngine;

public enum PlayerStat
{
    Health,
    Damage,
    Defense,
    AttackSpeed,
    MoveSpeed
}

[System.Serializable]
public class PlayerStatHolder
{
    public PlayerStat stat;
    public float value;
}




public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public Player player;
    public PlayerStatHolder[] stats; // Persistent stats, unaffected by dungeon runs
    public List<AdvancedPlayerStat> persistentAdvancedStats; // persistent advanced stats, unaffected by dungeon runs
    public int totalGoldAmount;

    private void Awake()
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
    public void SetPlayer()
    {
        player = FindFirstObjectByType<Player>();
    }
    public void ClearPlayer()
    {
        player = null;
    }
    public float GetStatValue(PlayerStat stat)
    {
        foreach (PlayerStatHolder holder in stats)
        {
            if (holder.stat == stat)
            {
                return holder.value;
            }
        }
        return 0f;
    }

    public void IncreaseStatValue(PlayerStat stat, float amount)
    {
        foreach (PlayerStatHolder holder in stats)
        {
            if (holder.stat == stat)
            {
                holder.value += amount;
                break;
            }
        }
    }
    public void IncreaseAdvancedStatValue(string statName, float amount)
    {
        foreach (AdvancedPlayerStat advStat in persistentAdvancedStats)
        {
            if (advStat.statName == statName)
            {
                advStat.currentValue += amount;
                break;
            }
        }
    }
    public void AddAdvancedStat(AdvancedPlayerStat newStat)
    {
        foreach (AdvancedPlayerStat advStat in persistentAdvancedStats) // check if already exists
        {
            if (advStat.statName == newStat.statName)
            {
                advStat.currentValue += newStat.currentValue;
                return;
            }
        }
        // add if not already existing
        persistentAdvancedStats.Add(newStat);
    }

    public float GetAdvancedStatValue(string statName)
    {
        float total = 0f;
        foreach (AdvancedPlayerStat advStat in persistentAdvancedStats)
        {
            if (advStat.statName == statName)
            {
                total += advStat.currentValue;
            }
        }
        return total;
    }

    public void AdjustGoldAmount(int amount)
    {
        totalGoldAmount += amount;
        if (totalGoldAmount < 0)
        {
            totalGoldAmount = 0;
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
