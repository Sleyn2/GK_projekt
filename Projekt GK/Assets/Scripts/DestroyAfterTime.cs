using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public int deathTime;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter == deathTime)
        {
            DestroyBullet();
        }
        counter++;
    }

    private void OnTriggerEnter()
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
