using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;

    public void Hit(float damage)
    {
        health -= damage;

        //restart the game if health goes below 0
        if(health <= 0)
        {
            gameManager.enemiesAlive--;
            Destroy(gameObject);
            //Destroy(this) // also works
        }
    }    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position; //returns a Vector3
        if(GetComponent<NavMeshAgent>().velocity.magnitude > 1) enemyAnimator.SetBool("isRunning", true);
        else enemyAnimator.SetBool("isRunning", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }


}
