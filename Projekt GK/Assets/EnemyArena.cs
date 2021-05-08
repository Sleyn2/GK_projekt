using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArena : MonoBehaviour
{
    public EnemyFollow enemy;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.chasingPlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.chasingPlayer = true;
        }
    }
}
