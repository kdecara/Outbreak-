using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 1000f;
    public float damage = 100f;
    public Animator playerAnimator;

    [SerializeField]
    private AudioSource weaponAudioSource; // Reference in Inspector

    // Start is called before the first frame update
    void Start()
    {
        // Make sure weaponAudioSource is assigned either via Inspector or via GetComponent<>():
        if (weaponAudioSource == null)
        {
            weaponAudioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetBool("isShooting", true);
        
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            EnemyManager enemyManager = hit.transform.GetComponentInParent<EnemyManager>();
            if (enemyManager != null)
            {
                Debug.Log(hit.transform.name);
                enemyManager.Hit(damage);
            }
        }

        // Play the shooting sound
        if (weaponAudioSource != null)
        {
            weaponAudioSource.Play();
        }
    }
}
