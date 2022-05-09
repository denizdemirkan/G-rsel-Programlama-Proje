using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    HealthHandler healthHandler;
    public GameHandler gameHandler;

    void Start()
    {
        // Düþmanýn HealthHandler isimli componentini alýr.
        healthHandler = GetComponent<HealthHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer paçýlan nesne Bullet componentine sahipse...
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            Bullet collusionBullet = collision.gameObject.GetComponent<Bullet>();
            healthHandler.health -= collusionBullet.damage;
            if(healthHandler.health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if(gameObject.GetComponent<Player>() != null)
        {
            gameHandler.PlayerDie();
        }
        Destroy(gameObject);
        gameHandler.CheckEnemyLeft();
    }

}
