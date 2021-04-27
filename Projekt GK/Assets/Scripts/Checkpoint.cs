using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public HealthManager healthManager;
    public Renderer rend;

    public Material cOn;
    public Material cOff;

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
        }

        rend.material = cOn;
    }

    public void CheckpointOff()
    {
        rend.material = cOff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            healthManager.SetSpawnPoint(this.transform.position);
            CheckpointOn();
        }
    }
}
