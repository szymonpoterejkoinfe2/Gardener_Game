using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectCharacteristics : MonoBehaviour
{
        public int myId;
        public Vector3 valueTarget, positionTarget;
        public string myName;
        public string uniqueId;
        public float growMultiplyer;

        //Function to generate uniqueId
        [ContextMenu("Generate Id")]
        private void GenerateId()
        {
            uniqueId = System.Guid.NewGuid().ToString();
        }

}

