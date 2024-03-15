using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderHandler : MonoBehaviour
{
    [SerializeField]
    MeshRenderer meshRenderer;

    void OnBecameVisible()
    {
        meshRenderer.enabled = true;
    }

    void OnBecameInvisible()
    {
        meshRenderer.enabled = false;
    }
}
