using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    EnemyStats enemyStats;
    
    float cooldown = 1;
    float tempCooldown = 0;

    void Start()
    {
        enemyStats = gameObject.GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        tempCooldown -= Time.deltaTime;
        if (tempCooldown <= 0)
        {
            Shot();
            tempCooldown = cooldown;
        }
    }

    void Shot()
    {
        for (int i = 1; i <= enemyStats.enemyFireLevel; i++)
        {
            var bulletPoint = gameObject.transform.Find("FirePoint" + i);
            Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
        }


    }
}
