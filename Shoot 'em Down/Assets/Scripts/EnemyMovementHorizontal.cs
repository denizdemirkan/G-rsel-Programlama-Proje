using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementHorizontal : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyPosition = transform.position;
        enemyPosition.x -= 1 * speed * Time.deltaTime;
        transform.position = enemyPosition;
    }
}
