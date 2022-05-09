using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementVertical : MonoBehaviour
{
    public float speed;
    private float timeToReverse;
    private Vector3 enemyPosition;
    private float offset = 0.5f;

    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move2();
    }

    void Move2()
    {
        float movementY;
        enemyPosition = transform.position;

        if (enemyPosition.y + offset >= Camera.main.orthographicSize)
        {
            direction = -1;
        }
        if (enemyPosition.y - offset <= -Camera.main.orthographicSize)
        {
            direction = 1;
        }

        movementY = direction * speed * Time.deltaTime;
        enemyPosition.y += movementY;
        transform.position = enemyPosition;
    }
}
