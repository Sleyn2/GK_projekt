using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Projectile : MonoBehaviour
{
    public AudioClip clipHurt;
    public GameObject explosionPrefab;
    public int deathTime;
    AudioSource audioHurt;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        audioHurt = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(counter == deathTime)
        {
            DestroyBullet();
        }
        counter++;
    }

    private void OnTriggerEnter()
    {
        AudioSource.PlayClipAtPoint(clipHurt, transform.position, PlayerPrefs.GetFloat("volumeEffects"));
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
