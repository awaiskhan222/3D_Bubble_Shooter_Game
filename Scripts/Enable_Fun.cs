using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable_Fun : MonoBehaviour
{
    Enemy_Ball_destroying enemy_Ball_Destroying;
    private void Start()
    {
        enemy_Ball_Destroying = GetComponent<Enemy_Ball_destroying>();
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemeyball")
        {
            Invoke("Enablefun", 3f);
        }
    }
    void Enablefun()
    {
        enemy_Ball_Destroying.enabled = true;
    }
}
