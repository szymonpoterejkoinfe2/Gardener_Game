using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitiom : MonoBehaviour
{
    public Animator Animator;

    public void SetTransitionToOne()
    {
        Animator.SetInteger("Transition", 1);


    }
}
