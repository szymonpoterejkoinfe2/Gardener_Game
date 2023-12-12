using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool haveObject = false;
    public Transform position;
    public int type;
    public GameObject iObject;

    void Awake()
    {
       position = gameObject.transform;
       iObject = this.gameObject;
    }

}
