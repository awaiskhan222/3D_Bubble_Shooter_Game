using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy_Ball_destroying : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemeyball")
        {

            Destroy(collision.gameObject);

        }
    }

}
