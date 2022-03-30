using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    ScoreScript scoreScript;
    private void Start()
    {
        scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreScript>();
    }
    void Update()
    {
        transform.Translate(Vector2.up * 4f * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreScript.Score(10);

        }
    }
}
