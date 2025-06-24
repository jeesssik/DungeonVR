/*using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackOnContact : MonoBehaviour
{
    public int damageAmount = 10;
    public float attackCooldown = 2f;

    private float lastAttackTime;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Frena el movimiento del agente
            agent.isStopped = true;

            // Daño al jugador si pasó el cooldown
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                IDamagable damageable = collision.gameObject.GetComponent<IDamagable>();
                if (damageable != null)
                {
                    damageable.Damage(damageAmount);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reanuda el movimiento si ya no está tocando al jugador
            agent.isStopped = false;
        }
    }
}
*/


using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackOnContact : MonoBehaviour
{
    public int damageAmount = 10;
    public float attackCooldown = 2f;

    private float lastAttackTime;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Frena el movimiento del agente
            agent.isStopped = true;

            // Daño al jugador si pasó el cooldown
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                IDamagable damageable = collision.gameObject.GetComponent<IDamagable>();
                if (damageable != null)
                {
                    damageable.Damage(damageAmount);
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reanuda el movimiento si ya no está tocando al jugador
            agent.isStopped = false;
        }
    }
}
