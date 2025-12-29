using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float attackRange;
    public EnemyStats stats;
    public virtual void Movement()
    {
        
    }
    public virtual void Attack()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
