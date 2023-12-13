using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class AnimalController : MonoBehaviour
{

    private Animator animator;
    private NavMeshAgent agent;
    string[] animalStates = { "State1", "State2", "State3" };
    bool animationActive;
    bool isWalking = false;

    private GameObject[] limitPoints;
    Transform targetPosition;
    float distance;
    public GameObject point;

    public int type;


    void Update()
    {

        // limitPoints = GameObject.FindGameObjectWithTag("PointHolder");
        if (isWalking == true)
        {
            transform.LookAt(targetPosition);
            distance = Vector3.Distance(transform.position, targetPosition.transform.position);
            if (distance < 0.1f)
            {
                Destroy(targetPosition.transform.gameObject);
                targetPosition = GeneratePoint();
            }
            else
            {
                Move();
                Walk();
            }
        }
        else {
            agent.destination = gameObject.transform.position;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        limitPoints = GetComponentInParent<BoundaryPoints>().boundaryPoints;

        animator = gameObject.GetComponent<Animator>();
        agent = gameObject.GetComponent<NavMeshAgent>();

        targetPosition = GeneratePoint();

        transform.LookAt(targetPosition);

        StartCoroutine(WaitToChangeState());


    }

    public void Eat()
    {
        animator.SetBool("isEating", true);
    }

    public void Idle()
    {
        animator.SetBool("isEating", false);
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);

    }

    public void Walk()
    {
        animator.SetBool("isWalking", true);
    }


    //Function to move object to target point
    void Move()
    {
        agent.destination = targetPosition.position;
         
    }

    // Generating random target point
    private Transform GeneratePoint()
    {
        Vector3 position = new Vector3(Random.Range(limitPoints[0].transform.position.x, limitPoints[1].transform.position.x), gameObject.transform.localPosition.y, Random.Range(limitPoints[2].transform.position.z, limitPoints[3].transform.position.z));
        // Debug.Log(position);

        //Creating Point Game Object 
        GameObject newPoint = Instantiate(point, new Vector3(0, 0, 0), UnityEngine.Quaternion.identity, transform.parent);
        //Debug.Log(transform.parent.name);
        newPoint.transform.position = position;
        newPoint.transform.localScale = new Vector3(1, 1f, 1);


        return newPoint.transform;

    }


    void SetAnimalState()
    {
        isWalking = false;

        int state = Random.Range(0, 3);

        Debug.Log($"State selected {state}");

        switch (state)
        {
            case 0:
                isWalking = false;
                Eat();
                break;

            case 1:
                targetPosition = GeneratePoint();
                isWalking = true;
                Move();
                break;

            default:
                isWalking = false;
                Idle();

                break;
        }
    }

    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private IEnumerator WaitToChangeState()
    {
        float waitTime = Random.Range(10, 20);
        while (true)
        {

            yield return new WaitForSeconds(waitTime);
            isWalking = false;
            Idle();
            SetAnimalState();


        }

    }
}
