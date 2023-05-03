using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    
    private int Health;
    private int MinHealth = 0;
    private bool dealingDamage = false;
    

    private GameObject player;
    
    private NavMeshAgent agent;
    private Transform target;

    public Color gizmosColor = Color.green;
    public LayerMask targetLayer;
    
    public float radius;
    public int damage;
    public int MaxHealth = 20;
    public virtual void Follow()
    {
      SearchTarget();
      MoveToTarget();
    }
   
   
    private void Start()
    {
        HealthLimit();
        agent = GetComponent<NavMeshAgent>();
    }
    private void SearchTarget()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    public  virtual void Attack()
    {
        DealDamage();
    }
    private void TakeDamage(int damage)
    {
        Health -= damage; 
        HealthLimit();
    }
    private void HealthLimit()
    {
        Health = Mathf.Clamp(MaxHealth, MinHealth, MaxHealth);
    }
    private void MoveToTarget()
    {
        agent.SetDestination(player.transform.position);
    }
    
    
    private void DealDamage()
    {
        if (dealingDamage)
        {
            player.GetComponent<Player>().TakeDamage(damage); 
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           dealingDamage = true;
        }
    }
    private void Death()
    {
        if (Health <=0)
        {

            Destroy(gameObject);
        }
    }
}
