using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side : MonoBehaviour
{
    public int Value;
    public Vector3 direction => transform.forward;
}