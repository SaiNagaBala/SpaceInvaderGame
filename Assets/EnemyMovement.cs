using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    int flag = 0;
    PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsGameOver == false)
        {
            if (flag == 0)
            {
                transform.Translate(Vector2.right * 3f * Time.deltaTime);
            }
            else if (flag == 1)
            {
                transform.Translate(Vector2.left * 3f * Time.deltaTime);
            }
            if (transform.position.x > 8.0f)
            {

                transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                flag = 1;
            }
            if (transform.position.x < -8.0f)
            {

                transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                flag = 0;
            }
        }
        if(transform.position.y<-4.6f)
        {
            Destroy(gameObject);
            playerMovement.IsGameOver = true;
            playerMovement.LostGame();
        }
       
    }
}
