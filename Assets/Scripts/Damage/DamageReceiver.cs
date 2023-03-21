using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] int health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageDealer iDamageDealer = collision.gameObject.GetComponent<IDamageDealer>();
        if (iDamageDealer != null)
        {
            HandleDamage(iDamageDealer.GetDamage());
        }
    }

    private void HandleDamage(Damage damage)
    {
        health -= damage.damage;
        if (health <= 0)
        {
            HandleDeath();
        }
    }
    private void HandleDeath()
    {
        Destroy(gameObject);
    }
}
