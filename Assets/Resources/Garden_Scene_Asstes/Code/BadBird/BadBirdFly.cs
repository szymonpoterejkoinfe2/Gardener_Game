using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBirdFly : MonoBehaviour
{
    public float speed = 1f;
    Transform targetPosition;
    float distance;
    bool canMove = false;
    public GameObject particle;


    // Update is called once per frame
    void Update()
    {
        //Movement Condition
        if(canMove)
        {
            transform.LookAt(targetPosition);

            distance = Vector3.Distance(transform.position, targetPosition.transform.position);
            if (distance < 1f)
            {
                //GameObject.FindGameObjectWithTag("MovedSoil");
                Destroy(gameObject);

            }
            else
            {
                Move();
            }

            if (GameObject.FindGameObjectWithTag("MovedSoil") == null)
            {
                Kill();
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

    public void Kill()
    {
       
        Destroy(gameObject);
        GameObject feathers = Instantiate(particle,transform.position, Quaternion.Euler(0,0,0));
        feathers.GetComponent<ParticleSystem>().Play();
        Destroy(feathers, 1f);
    }
}
