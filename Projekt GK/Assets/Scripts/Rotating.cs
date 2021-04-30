using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    float timeCounter = 0;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, -114f, 0f) * Time.deltaTime);
        timeCounter += Time.deltaTime;
        float x = Mathf.Cos(timeCounter*2) + startPosition.x;
        float y = startPosition.y;
        float z = Mathf.Sin(timeCounter*2) + startPosition.z;
        if(Mathf.Sin(timeCounter * 2) >= 0.9999f)
        {
            transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }
        transform.position = new Vector3(x, y, z);



    }
}
