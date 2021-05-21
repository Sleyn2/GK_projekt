using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    AudioSource audioShot;
    public AudioClip audioClipShot;
    float effectsVolume;

    //States
    public float attackRange;

    // Start is called before the first frame update 
    void Start()
    {
        audioShot = gameObject.GetComponent<AudioSource>();
        effectsVolume = PlayerPrefs.GetFloat("volumeEffects");
    }
    private void Update()
    {
        //Check for sight and attack range
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if(distanceToPlayer < attackRange)
        {
            
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            
            audioShot.PlayOneShot(audioClipShot, effectsVolume);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}