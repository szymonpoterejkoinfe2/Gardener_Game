using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLogic : MonoBehaviour
{

    GameObject SoilToCheck, Camera;
    float Timer = 0f;
    public float GrowTime = 10f;
    float MaxSize = 1.1f;
    public bool HaveManager = false;
    
    // Beginning of Scailing Coroutine
    public void StartGrowing()
    {
        HaveManager = true;
            StartCoroutine(GrowWithManager());
    }

    // Scaling plant object with time
    private IEnumerator GrowWithManager()
    {
        Camera = GameObject.Find("Camera");
        Vector3 StartScale = new Vector3(0f, 0f, 0f);
        Vector3 MaxScale = new Vector3(0.21f, MaxSize, 0.21f);

        while (HaveManager)
        {
            while (Timer <= GrowTime)
            {
                transform.localScale = Vector3.Lerp(StartScale, MaxScale, Timer / GrowTime);
                Timer += Time.deltaTime;
                yield return null;
            }

            Camera.GetComponent<GrowPlant>().PlantFullyGrown();

            Timer = 0;

        }
    }
}
