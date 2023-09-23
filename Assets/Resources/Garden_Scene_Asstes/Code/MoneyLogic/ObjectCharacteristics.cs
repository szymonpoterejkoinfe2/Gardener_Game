using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectCharacteristics : MonoBehaviour
{
        public int myId;
        public float[] valueTarget;
        public string myName;
        public string uniqueId;

        //Function to generate uniqueId
        [ContextMenu("Generate Id")]
        private void GenerateId()
        {
            uniqueId = System.Guid.NewGuid().ToString();
        }

}

