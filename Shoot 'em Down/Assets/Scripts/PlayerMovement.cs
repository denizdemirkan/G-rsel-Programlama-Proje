using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStats playerStats;
    private float offset = 0.5f;
    
    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMove = Time.deltaTime * playerStats.playerSpeed * Input.GetAxis("Vertical");
        float horizontalMove = Time.deltaTime * playerStats.playerSpeed * Input.GetAxis("Horizontal");

        Vector3 playerPosition = transform.position;

        playerPosition.y += verticalMove;
        playerPosition.x += horizontalMove;

        if(playerPosition.y + offset > Camera.main.orthographicSize)
        {
            playerPosition.y = Camera.main.orthographicSize - offset;
        }
        if (playerPosition.y - offset < -Camera.main.orthographicSize)
        {
            playerPosition.y = -Camera.main.orthographicSize + offset;
        }

        float screenRatio = Screen.width / Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if(playerPosition.x + offset > widthOrtho)
        {
            playerPosition.x = widthOrtho - offset;
        }
        if (playerPosition.x - offset < -widthOrtho)
        {
            playerPosition.x = -widthOrtho + offset;
        }

        transform.position = playerPosition;


    }

}
