using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSave : MonoBehaviour
{
    private IDataService DataService = new JasonDataService();

    public class ExitTime
    {
        public System.DateTime extTime;

        public ExitTime() {}
        public ExitTime(System.DateTime time) { extTime = time; }
        public void SetTime()
        {
            extTime = System.DateTime.UtcNow;
        }
    }

    public ExitTime eTime;

    TimeSave()
    {
        eTime = new ExitTime();
        eTime.SetTime();
    }

    private IEnumerator SetTime()
    {
        while (true) {

            yield return new WaitForSeconds(5);
            eTime.SetTime();

            if (DataService.SaveData("/ExitTime.json", eTime, true))
            {
                Debug.Log("Time saved");
            }

        }


    }

    void Start()
    {

        StartCoroutine(SetTime());
    }
}
