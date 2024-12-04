
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public Text roundNumber;
    public Text roundsSurvived;
    public GameObject endScreen;   

    private bool isWaitingForNextWave = false; // Add this flag

    void Start()
    {
        endScreen.SetActive(false);
    }

    void Update()
    {
        if (enemiesAlive == 0 && !isWaitingForNextWave)
        {
            round++;
            StartCoroutine(DelayNextWave(round, 10f)); // Change delay to 10 seconds
            roundNumber.text = "Round: " + round.ToString();
            isWaitingForNextWave = true; // Set flag to prevent multiple coroutines
        }
    }

    IEnumerator DelayNextWave(int round, float delay)
    {
        yield return new WaitForSeconds(delay);
        NextWave(round);
        isWaitingForNextWave = false; // Reset flag after spawning
    }

    public void NextWave(int round)
    {
        for (int i = 0; i < round + 1; i++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

            enemySpawned.GetComponent<EnemyManager>().gameManager = this;

            enemiesAlive++;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("EARTH");   
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MAINMENU");
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;   
        endScreen.SetActive(true);
        roundsSurvived.text = round.ToString();   
    }
}