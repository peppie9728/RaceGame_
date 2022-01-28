using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackBuilder : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;


    public Transform GetEndPoint()
    {
        return endPoint;
    }
    public Transform GetStartPoint()
    {
        return startPoint;
    }
}
