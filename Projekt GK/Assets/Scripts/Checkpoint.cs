using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager healthManager;

    public GameObject explosionPrefab;
    public bool active;
    public ParticleSystem magicznyPylLauncher;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
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

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }


}
