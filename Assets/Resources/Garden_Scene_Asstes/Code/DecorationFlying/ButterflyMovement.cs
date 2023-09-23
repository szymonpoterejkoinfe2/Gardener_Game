using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyMovement : MonoBehaviour
{
    public float speed = 1f;
    GameObject limitPoints;
    Transform targetPosition;
    float distance;

   public GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        limitPoints = transform.parent.gameObject;
        targetPosition = GeneratePoint();

        transform.LookAt(targetPosition);

    }

    // Update is called once per frame
    void Update()
    {
       // limitPoints = GameObject.FindGameObjectWithTag("PointHolder");

        limitPoints = transform.parent.gameObject;

        transform.LookAt(targetPosition);

        distance = Vector3.Distance(transform.position, targetPosition.transform.position);
        if (distance < 1f)
        {
            Destroy(targetPosition.transform.gameObject);
            targetPosition = GeneratePoint();

        }
        else {
            Move();
        }
       
    }

    //Function to move object to target point
    void Move()
    { 
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Generating random target point
     Transform GeneratePoint()
    {
        Vector3 position = new Vector3(Random.Range(limitPoints.GetComponentInChildren<LimitPoints>().xAxis[1].localPosition.x, limitPoints.GetComponentInChildren<LimitPoints>().xAxis[0].localPosition.x), Random.Range(limitPoints.GetComponentInChildren<LimitPoints>().yAxis[1].localPosition.y, limitPoints.GetComponentInChildren<LimitPoints>().yAxis[0].localPosition.y), Random.Range(limitPoints.GetComponentInChildren<LimitPoints>().zAxis[1].localPosition.z, limitPoints.GetComponentInChildren<LimitPoints>().zAxis[0].localPosition.z));
        Debug.Log(position);

        //Creating Point Game Object 
        GameObject newPoint = Instantiate(point, new Vector3(0, 0, 0), UnityEngine.Quaternion.identity, transform.parent);
        //Debug.Log(transform.parent.name);
        newPoint.transform.localPosition = position;
        newPoint.transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);


        return newPoint.transform;

    }
}
