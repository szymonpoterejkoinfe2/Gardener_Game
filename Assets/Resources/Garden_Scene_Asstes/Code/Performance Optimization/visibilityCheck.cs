using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visibilityCheck : MonoBehaviour
{
    [SerializeField]
    SkyAnimalController skyAnimalController;

    [SerializeField]
    SkinnedMeshRenderer renderer;

    private void Update()
    {
        if (Camera.main.orthographicSize > 30 && Camera.main.name == "MainCamera")
        {
            renderer.enabled = false;
        }
        else {
            renderer.enabled = true;
        }

    }

    private void OnBecameVisible()
    {
        skyAnimalController.StartMovement();
    }

    private void OnBecameInvisible()
    {
        skyAnimalController.StopMovement();
    }
}
