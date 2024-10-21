using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X_AXIS_ROTATIONSCRIPT : MonoBehaviour
{
   
    void Update()
    {
       transform.Rotate(1 * 10 * Time.deltaTime, 0, 0);
    }
}
