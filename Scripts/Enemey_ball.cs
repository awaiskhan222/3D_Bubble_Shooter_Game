using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey_ball : MonoBehaviour
{

    public Color ballcolor;
    

    private void Start()
    {
        ballcolor = gameObject.GetComponent<Renderer>().material.color; 
        
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
            green_Ball_Destroy_Script.destroyfun();
        }
    }*/

}
