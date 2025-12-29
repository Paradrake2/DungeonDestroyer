using UnityEngine;

public enum EnemyStat
{
    MaxHealth,
    CurrentHealth,
    MoveSpeed,
    Damage,
    Defense,
    AttackSpeed
}

public class EnemyStatHolder
{
    public EnemyStat stat;
    public float value;
}

public class EnemyStats : MonoBehaviour
{
    public EnemyStatHolder[] stats;
    public float GetStatValue(EnemyStat stat)
    {
        foreach (EnemyStatHolder holder in stats)
        {
            if (holder.stat == stat)
            {
                return holder.value;
            }
        }
        return 0f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
