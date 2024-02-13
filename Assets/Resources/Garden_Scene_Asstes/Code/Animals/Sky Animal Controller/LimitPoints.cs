using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPoints : MonoBehaviour
{
    [SerializeField]
    public AltitudeBoundaries highAltitude;

    [SerializeField]
    public AltitudeBoundaries mediumAltitude;

    [SerializeField]
    public AltitudeBoundaries lowAltitude;
}

[Serializable]
public class AltitudeBoundaries
{
    [SerializeField]
    public CoordinateBoundaries xAxis;

    [SerializeField]
    public CoordinateBoundaries yAxis;

    [SerializeField]
    public CoordinateBoundaries zAxis;
}

[Serializable]
public class CoordinateBoundaries
{
    [SerializeField]
    public Transform max;

    [SerializeField]
    public Transform min;

}