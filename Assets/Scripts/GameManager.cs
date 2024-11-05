using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public Text roundNumber;
    public Text roundsSurvived;
    public GameObject endScreen;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            roundNumber.text = "Round: " + round.ToString();
        }
        
    }

    public void NextWave(int round)
    {
        for(int i = 0; i < round; i++) //spawn one more enemy per round
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            enemySpawned.GetComponent<EnemyManager>().gameManager = GetComponent<GameManager>(); //neat trick

            enemiesAlive++;
        }
    }

    public void restart()
    {
        Time.timeScale = 1; //needed to unfreeze the game 
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None; //allows us to move out of the game
        endScreen.SetActive(true);
        roundsSurvived.text = round.ToString();
    }
}
