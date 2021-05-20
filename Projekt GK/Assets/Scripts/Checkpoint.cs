using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Checkpoint : MonoBehaviour
{
    public HealthManager healthManager;

    public GameObject explosionPrefab;
    public bool active;
    public ParticleSystem magicznyPylLauncher;

    public AudioClip checkpointAudio;

    public AudioMixer effectsMixer;

    AudioSource getCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        getCheckpoint = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckpointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach (Checkpoint cp in checkpoints)
        {
            cp.CheckpointOff();
            cp.active = false;
        }
        ParticleSystem.MainModule psMain = magicznyPylLauncher.main;
        psMain.startColor = new Color(0, 155, 0);
        active = true;
    }

    public void CheckpointOff()
    {
        ParticleSystem.MainModule psMain = magicznyPylLauncher.main;
        psMain.startColor = new Color(255, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && active == false)
        {
            healthManager.SetSpawnPoint(this.transform.position);
            CheckpointOn();

            effectsMixer.GetFloat("volume", out float effectsVolume);

            getCheckpoint.PlayOneShot(checkpointAudio, effectsVolume * 0.1F);

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }


}
