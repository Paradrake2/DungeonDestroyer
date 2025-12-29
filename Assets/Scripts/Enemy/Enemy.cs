using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats stats;


    public void TakeDamage(float damage)
    {
        float effectiveDamage = damage - stats.GetStatValue(EnemyStat.Defense);
        effectiveDamage = Mathf.Max(effectiveDamage, 1); // Prevent negative damage
        float currentHealth = stats.GetStatValue(EnemyStat.CurrentHealth);
        currentHealth -= effectiveDamage;
        // Update the CurrentHealth stat
        foreach (EnemyStatHolder holder in stats.stats)
        {
            if (holder.stat == EnemyStat.CurrentHealth)
            {
                holder.value = currentHealth;
                break;
            }
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        // Give XP, drop loot
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
