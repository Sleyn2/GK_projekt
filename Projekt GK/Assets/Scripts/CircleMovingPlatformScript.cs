using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovingPlatformScript : MonoBehaviour
{
    public GameObject Player;
    public float scale;
    public float xWidth;
    public float zWidth;
    float timeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeCounter += Time.deltaTime * scale;
        float x = Mathf.Cos(timeCounter) * xWidth;
        float y = transform.position.y;
        float z = Mathf.Sin(timeCounter) * zWidth;

        transform.position = new Vector3(transform.position.x+x, transform.position.y, transform.position.z+z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}
