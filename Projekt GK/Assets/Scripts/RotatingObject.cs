using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{

    public float rotateSpeed;
    public string axis;
    float x = 0;
    float y = 0;
    float z = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (axis == "x")
        {
            x = rotateSpeed;
        }
        else if (axis == "y")
        {
            y = rotateSpeed;
        }
        else if (axis == "z")
        {
            z = rotateSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
    }
}
