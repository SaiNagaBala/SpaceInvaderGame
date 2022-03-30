using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    int temporary = 0;
    PlayerMovement playerMovement;
    float timer = 0;
    float timeToMove = 0.5f;
    int numOfMovements = 0;
    float speed = 0.25f;

    public GameObject enemy;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;

    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(numOfMovements==40)
        {
            transform.Translate(new Vector3(0, -1, 0));
            numOfMovements = -1;
            speed = -speed;
            timer = 0;
        }

        timer += Time.deltaTime;
        if ((timer > timeToMove) && numOfMovements<40)
        {
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;
            numOfMovements++;
        }
        FireEnemyProjectile();
    }
    void FireEnemyProjectile()
    {
        if(Random.Range(0f,5f)<1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f, 0), enemy.transform.rotation) as GameObject;
        }
    }
}
