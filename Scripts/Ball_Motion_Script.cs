using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Motion_Script : MonoBehaviour
{
    public float launchSpeed = 10f;
    public Transform launchPoint;

    private BoxCollider boxcollider;
    // Start is called before the first frame update

    Player_Script player_script;
    private GameObject[] obj;

    private Rigidbody rb;
    public bool isShoot = false;

    public Color ballcolor;
    
    private void Start()
    {
        ballcolor = GetComponent<Renderer>().material.color;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        /* player_script = GameObject.FindGameObjectWithTag("playerscript").GetComponent<Player_Script>();*/
        obj = GameObject.FindGameObjectsWithTag("enemeygreen");
    }
    public void Awake()
    {
        GetComponent<Rigidbody>().velocity = launchSpeed * launchPoint.up;
        /*Invoke("destroyfun", 3f);*/

    }


    private void Update()
    {
        if(isShoot)
        {
            rb.isKinematic = false;
            rb.velocity = launchSpeed * launchPoint.up;
            isShoot = false;
        }
        
    }
    
    

    //destroy enemy ball functions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemeyball"))
        {
            
            Color enemycolor = collision.gameObject.GetComponent<Renderer>().material.color;

            if (enemycolor == ballcolor)
            {
                DestroySameColorBall(enemycolor);
                
            }
        }
    }


    void DestroySameColorBall(Color colortodestroy)
    {
        Enemey_ball[] allenemyBall = FindObjectsOfType<Enemey_ball>();

        foreach (Enemey_ball ball in allenemyBall)
        {
            if (ball.GetComponent<Renderer>().material.color == colortodestroy)
            {
                /*Destroy(ball.gameObject);*/
                ball.GetComponent<Rigidbody>().mass = 2;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().isKinematic = false;
                
            }
        }
    }


}
