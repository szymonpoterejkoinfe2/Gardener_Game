using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NavMeshBuilder : MonoBehaviour
{

    [SerializeField]
    private NavMeshSurface surface;

    // Start is called before the first frame update
    void Update()
    {
        surface.BuildNavMesh();
    }

 
}
