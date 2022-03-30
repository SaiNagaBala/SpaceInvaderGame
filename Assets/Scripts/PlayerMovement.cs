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
    public GameObject enemyPrefab;
    public GameObject enemyBullet;
    private float time;
    private float inputX; 
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
        /*for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 4; column++)
            {
                var enemie = Instantiate(enemyPrefab, new Vector2(-7.6f + column, 4.03f + row), Quaternion.identity);
                
            }
        }*/

    }
    



    // Update is called once per frame
    void Update()
    {
        if (IsGameOver == false)
        {
            inputX = Input.GetAxis("Horizontal");

            transform.Translate(inputX * playerSpeed * Time.deltaTime, 0f, 0f);

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0,5*playerSpeed* Time.deltaTime,0));
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, -5 * playerSpeed * Time.deltaTime, 0));
            }
            if (transform.position.x < -8.0f)
            {
                transform.position = new Vector2(-8.0f, transform.position.y);
            }

            if (transform.position.x > 8.0f)
            {
                transform.position = new Vector2(8.0f, transform.position.y);
            }

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
                    Vector3 enemyPosition = enemy.transform.position ;
                    Instantiate(enemyBullet, enemyPosition + new Vector3(0f, -0.245f, 0f), Quaternion.identity);
                    time = 0f;
                
            }
        }
        if(scoreScript.score==100)
        {
            resetPage.SetActive(true);
            gameText.text = "Lift The Title";
            IsGameOver = true;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if (playerLives >= 1 && playerLives <=3)
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

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Quit()
    {
        SceneManager.LoadScene(0);
    }

}
