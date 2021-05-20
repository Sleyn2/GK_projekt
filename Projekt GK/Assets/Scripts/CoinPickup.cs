using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CoinPickup : MonoBehaviour
{
    public ParticleSystem getCoin;

    public int coinValue;

    public AudioClip getCoinAudio;

    public AudioMixer effectsMixer;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<GameManager>().AddCoin(coinValue);

            Instantiate(getCoin, transform.position, Quaternion.identity);

            effectsMixer.GetFloat("volume", out float effectsVolume);

            AudioSource.PlayClipAtPoint(getCoinAudio, transform.position, effectsVolume);

            Destroy(gameObject);

        }
    }
}
