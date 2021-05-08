using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;

    public bool chasingPlayer = false;

    //patrolowanie
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public Vector3 startPoint;

    // Start is called before the first frame update 
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        chasingPlayer = false;
        startPoint = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(target.position, transform.position);
        if (chasingPlayer)
        {
                Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
                rig.MovePosition(pos);
                transform.LookAt(target);
        }else
        {
            if (!walkPointSet)
            {
                float randomZ = Random.Range(-walkPointRange, walkPointRange);
                float randomX = Random.Range(-walkPointRange, walkPointRange);
                walkPoint = new Vector3(startPoint.x + randomX, transform.position.y, startPoint.z + randomZ);
                walkPointSet = true;
            }
            else
            {
                if (Vector3.Distance(transform.position, walkPoint) > 0.5f)
                {
                    Vector3 pos = Vector3.MoveTowards(transform.position, walkPoint, speed * Time.fixedDeltaTime);
                    rig.MovePosition(pos);
                    Quaternion rotation = Quaternion.LookRotation(walkPoint - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
                } else
                {
                    walkPointSet = false;
                }
            }
        }
    }
}