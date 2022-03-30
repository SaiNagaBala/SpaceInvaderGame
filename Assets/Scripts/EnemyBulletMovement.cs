using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    private float time;
    public int bulletSpeed;
    public GameObject enemyBullet;
    // Start is called before the first frame update
    // Update is called once per frame
   
    void Update()
    {
      
            
            transform.Translate(Vector2.down * bulletSpeed);
           
                    
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    
}
