using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 1000f; //range of weapon
    public float damage = 100f;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            EnemyManager enemyManager = hit.transform.GetComponentInParent<EnemyManager>();
            if(enemyManager != null) //if not null we hit an enemy
            {
                Debug.Log(hit.transform.name);
                enemyManager.Hit(damage);
            }
        }


    }
}
