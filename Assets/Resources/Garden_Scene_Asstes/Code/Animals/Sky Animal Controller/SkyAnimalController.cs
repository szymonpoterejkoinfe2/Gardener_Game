using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyAnimalController : MonoBehaviour
{
    [SerializeField]
    private AnimationClip animalAnimationClip;
    [SerializeField]
    private altitude preferredAltitude;
    private Animator anim;
    private GameObject parent;
    private LimitPoints limitPoints;
    private Transform targetPosition;
    private float distance;

    public float rotationSpeed = 1.0f;
    public float moveSpeed = 1f;
    public GameObject point;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        parent = transform.parent.gameObject;

        targetPosition = GenerateTargetPosition();

        PlayAnimation(animalAnimationClip);
    }

    // Update is called once per frame
    void Update()
    {

        // Determine direction towards the target only considering the y-axis.
        Vector3 targetDirection = targetPosition.position - transform.position;
        targetDirection.y = 0; // Set y-component to 0

        // The step size is equal to speed times frame time.
        float singleStep = rotationSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Quaternion newRotation = Quaternion.LookRotation(targetDirection);

        // Apply rotation only around the y-axis
        newRotation.x = 0;
        newRotation.z = 0;

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, singleStep);


        distance = Vector3.Distance(transform.position, targetPosition.position);
        if (distance < 0.5f || distance > 60f)
        {
            Destroy(targetPosition.transform.gameObject);
            targetPosition = GenerateTargetPosition();
        }
        else
        {
           Move();
        }
    }

    //Function to play animal animation
    private void PlayAnimation(AnimationClip clip)
    {
        anim.Play(clip.name);
    }

    //Function to move object to target point
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
    }

    // Generating random target point
    private Transform GenerateTargetPosition()
    {
        limitPoints = parent.GetComponentInChildren<LimitPoints>();
        GameObject newPoint = Instantiate(point, new Vector3(0, 0, 0), UnityEngine.Quaternion.identity, transform.parent);

        if (preferredAltitude == altitude.High)
        {
            newPoint.transform.localPosition = new Vector3(Random.Range(limitPoints.highAltitude.xAxis.min.localPosition.x, limitPoints.highAltitude.xAxis.max.localPosition.x), Random.Range(limitPoints.highAltitude.yAxis.min.localPosition.y, limitPoints.highAltitude.yAxis.max.localPosition.y), Random.Range(limitPoints.highAltitude.zAxis.min.localPosition.z, limitPoints.highAltitude.zAxis.max.localPosition.z));
        }
        else if (preferredAltitude == altitude.Medium)
        {
            newPoint.transform.localPosition = new Vector3(Random.Range(limitPoints.mediumAltitude.xAxis.min.localPosition.x, limitPoints.mediumAltitude.xAxis.max.localPosition.x), Random.Range(limitPoints.mediumAltitude.yAxis.min.localPosition.y, limitPoints.mediumAltitude.yAxis.max.localPosition.y), Random.Range(limitPoints.mediumAltitude.zAxis.min.localPosition.z, limitPoints.mediumAltitude.zAxis.max.localPosition.z));
        }
        else {
            newPoint.transform.localPosition = new Vector3(Random.Range(limitPoints.lowAltitude.xAxis.min.localPosition.x, limitPoints.lowAltitude.xAxis.max.localPosition.x), Random.Range(limitPoints.lowAltitude.yAxis.min.localPosition.y, limitPoints.lowAltitude.yAxis.max.localPosition.y), Random.Range(limitPoints.lowAltitude.zAxis.min.localPosition.z, limitPoints.lowAltitude.zAxis.max.localPosition.z));
        }

        newPoint.transform.localScale = new Vector3(0.1f, 0.5f, 0.1f);
        return newPoint.transform;
    }

    enum altitude 
    {
        High,
        Medium,
        Low
    };
}
