using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    public float timer;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 position = transform.position;

        Vector3 velocity = new Vector3(0, Time.deltaTime * speed, 0);

        position += transform.rotation * velocity;

        transform.position = position;


        // Merminin silinmesi için gerekli kod
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
