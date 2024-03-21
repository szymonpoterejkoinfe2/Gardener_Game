using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFly : MonoBehaviour
{
    float speed = 1;
    Transform targetPosition;
    float distance;
    bool canMove = false;
    bool visible;

    [SerializeField]
    MeshRenderer[] renderers;

    private CloudEmitter cloudEmitter;

    void Start()
    {
        cloudEmitter = FindObjectOfType<CloudEmitter>();
        speed = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {

        if (canMove && Camera.main.name == "MainCamera")
        {
            ActivateRenderers(renderers);

            transform.LookAt(targetPosition);

            distance = Vector3.Distance(transform.position, targetPosition.transform.position);
            if (distance < 1f)
            {
                cloudEmitter.CloudDestroyed();

                Destroy(gameObject);

            }
            else
            {
                Move();
            }
        }
        else {
            DeactivateRenderers(renderers);
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

    private void DeactivateRenderers(MeshRenderer[] renderers)
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = false;
        }
    }

    private void ActivateRenderers(MeshRenderer[] renderers)
    {
        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }

}
