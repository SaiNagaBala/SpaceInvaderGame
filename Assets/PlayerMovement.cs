using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    public GameObject bulletSpawn;
    public GameObject enemy;
    public GameObject enemyBullet;
    float time;
    //Rigidbody2D rb;
   
    public GameObject resetPage;
    public Text gameText;
    public Button quit;
    public Button restart;
    public Text liveText;
    ScoreScript scoreScript;
    Vector3 playerPosition;
    public bool IsGameOver=false;
    int playerLives = 3;
    
    void Start()
    {

        
        quit.onClick.AddListener(Quit);
        restart.onClick.AddListener(Restart);
        scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreScript>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                var enem = Instantiate(enemy, new Vector2(-7.6f + j, 4.03f - i), Quaternion.identity);
                enem.name = "Enemy" + i + j;
                //Debug.Log(enem.name); 

            }
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Quit()
    {
        SceneManager.LoadScene(0);
    }



    // Update is called once per frame
    void Update()
    {
        if (IsGameOver == false)
        {
            float inputX = Input.GetAxis("Horizontal");
            transform.Translate(inputX * playerSpeed * Time.deltaTime, 0f, 0f);
            if (transform.position.x < -8.0f)
                transform.position = new Vector2(-8.0f, transform.position.y);
            if (transform.position.x > 8.0f)
                transform.position = new Vector2(8.0f, transform.position.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bulletSpawn, transform.position + new Vector3(0.01f, 0.5f, 0f), Quaternion.identity);

            }
            time = time + Time.deltaTime;
            int i = Random.Range(0, 3);
            int j = Random.Range(0, 4);

            GameObject enemy = GameObject.Find("Enemy" + i + j);

            if (time >= 3.5f&& enemy!=null)
            {
                    Vector3 enemyPosition = enemy.transform.position;
                    Instantiate(enemyBullet, enemyPosition + new Vector3(0f, -0.245f, 0f), Quaternion.identity);
                    //Debug.Log("Bullet launching from"+enemy.name);
                    time = 0f;
                
            }
        }
        if(scoreScript.score==200)
        {
            resetPage.SetActive(true);
            gameText.text = "Won the game";
            IsGameOver = true;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if (playerLives >= 1)
            {
                liveText.text = "Lives: " + playerLives;
                playerLives--;   
                Destroy(collision.gameObject);
                
            }
            else
            {
                LostGame();
            }

        }
    }

    public void LostGame()
    {
        gameObject.SetActive(false);
        resetPage.SetActive(true);
        gameText.text = "Lost the Game";
        IsGameOver = true;
    }
   
}
