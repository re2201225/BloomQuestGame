using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // fixed casing
        {
            var health = collision.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(); // damage is always 1 based on your PlayerHealth
            }
        }
    }
}
