using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Script : MonoBehaviour
{
    private Touch Touch;
    public Transform launchPoint;
    public GameObject projectile;
    public float launchSpeed = 10f;
    private Rigidbody rb;
    /*[Header("****Trajectory Display****")]
    public LineRenderer lineRenderer;
    public int linePoints = 175;
    public float timeIntervalInPoints = 0.01f;*/


    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    [SerializeField] private GameObject[] enemyballs;

    Vector3 direction = Vector3.up;
    private GameObject obj;

    public GameObject ball;
    Ball_Motion_Script ball_motion;

    public GameObject win_panel;
    public GameObject loos_panel;
    

    private void Start()
    {

        win_panel.SetActive(false);
        ActiveShootBall();
        ball_motion = GameObject.FindGameObjectWithTag("player").GetComponent<Ball_Motion_Script>();
    }

    void ActiveShootBall()
    {
        ball = fireballs[FindFireball()];
        ball.transform.position = firePoint.position;
        ball.SetActive(true);
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch = Input.GetTouch(0);

            if (Touch.phase == TouchPhase.Ended)
            {
                attack();

            }
        }
        enemyballs = GameObject.FindGameObjectsWithTag("enemeyball");
        if (enemyballs.Length == 0)
        {
            win_panel.SetActive(true);
            Invoke("win_panel_fun", 3f);
            print("game win");
        }
    }

    public void attack()
    {
        /*fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].SetActive(true);
        print("attack function is calling");*/

        ball.GetComponent<Ball_Motion_Script>().isShoot = true;
        Invoke("ActiveShootBall", 0.5f);
    }


    private int FindFireball()
    {
       
        for (int i = 0; i < fireballs.Length; i++)
        {

            if (!fireballs[i].activeInHierarchy)
            {
                
                if (i == 15 )
                {
                    loos_panel.SetActive(true);
                    print("Game over");

                    /*enemyballs = GameObject.FindGameObjectsWithTag("enemeyball");
                    if (enemyballs.Length == null)
                    {
                        Invoke("win_panel_fun", 3f);
                        print("game win");
                    }
                    else
                    {
                        loos_panel.SetActive(true);
                        print("Game over");
                    }*/
                    
                }
                
                
                return i;

            }

        }
        return 0;
    }

    public void win_panel_fun()
    {
        win_panel.SetActive(true);
    }
}
