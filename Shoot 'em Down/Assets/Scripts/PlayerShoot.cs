using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    PlayerStats playerStats;
    float tempCooldown = 0;

    private SoundHandler soundHandler;

    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
        soundHandler = gameObject.GetComponent<SoundHandler>();
    }

    void Update()
    {
        tempCooldown -= Time.deltaTime;
        if(Input.GetButton("Fire1") && tempCooldown <= 0)
        {
            Shot();
            tempCooldown = playerStats.weaponCooldown;
        }
    }

    void Shot()
    {
        for(int i = 1; i <= playerStats.playerFireLevel; i++)
        {
            var bulletPoint = gameObject.transform.Find("FirePoint" + i);
            Instantiate(bulletPrefab, bulletPoint.transform.position, bulletPoint.transform.rotation);
        }
        soundHandler.ShootSound();
    }
}
