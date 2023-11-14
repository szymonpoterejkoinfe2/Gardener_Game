using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFly : MonoBehaviour
{
    public float speed = 1; 
    Transform targetPosition;
    float distance;
    bool canMove = false;

    void Start()
    { 
    speed = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.LookAt(targetPosition);

            distance = Vector3.Distance(transform.position, targetPosition.transform.position);
            if (distance < 1f)
            {
                Destroy(gameObject);

            }
            else
            {
                Move();
            }
        }
    }

    //Function to move object to target point
    void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //Function to start object movement
    public void StartMoving(Transform target)
    {
        targetPosition = target;
        canMove = true;
    }

}
