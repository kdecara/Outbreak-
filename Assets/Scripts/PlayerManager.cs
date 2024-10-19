using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public Text healthText;
    public GameManager gameManager;
    public void Hit(float damage)
    {
        health -= damage;
        healthText.text = "Health " + health.ToString();

        //restart the game if health goes below 0
        if(health <= 0)
        {
            gameManager.EndGame();
        }
    }
}
