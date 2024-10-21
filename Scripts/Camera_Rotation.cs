using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{
    public float sensitivity = 0.5f;
    public float minAngle = -20f;
    public float maxAngle = 20f;
    private float XRotation;
    private float YRotation;
    [SerializeField] private Transform Playerbody;

    public GameObject ball_child;

    public bool player_ball_bool = false;

    private Touch touch;
    private float speedmodifier;

    

    [Header("****Trajectory Display****")]
    public LineRenderer lineRenderer;
    public int linePoints = 175;
    public float timeIntervalInPoints = 0.1f;

    public Transform launchPoint;
    public float launchSpeed = 10f;

    private void Start()
    {
        ball_child = GameObject.FindGameObjectWithTag("player");
        speedmodifier = 0.05f;
        
    }
    void Update()
    {
        DrawTrajectory();
        if (Input.touchCount > 0)
        {
            
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved )
            {
                XRotation -= touch.deltaPosition.y * speedmodifier ;
                YRotation -= touch.deltaPosition.x * speedmodifier ;
                XRotation = Mathf.Clamp(XRotation, -20f, 20f);
                YRotation = Mathf.Clamp(YRotation, -20f, 20f);
                transform.localRotation = Quaternion.Euler(XRotation, -YRotation, 0);

                /*if (lineRenderer != null)
                {

                    DrawTrajectory();
                    lineRenderer.enabled = true;
                }
                else
                    lineRenderer.enabled = false;

                print("calling trajectory");
*/

            }
        }
       
    }

    public void DrawTrajectory()
    {
        Vector3 origin = launchPoint.position;
        Vector3 startVelocity = launchSpeed * launchPoint.up;
        lineRenderer.positionCount = linePoints;
        float time = 0;
        for (int i = 0; i < linePoints; i++)
        {
            // s = u*t + 1/2*g*t*t
            var x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            var y = (startVelocity.y * time) + (Physics.gravity.y / 2 * time * time);
            var z = (startVelocity.z * time) + (Physics.gravity.z / 2 * time * time);
            Vector3 point = new Vector3(x, y, z);
            lineRenderer.SetPosition(i, origin + point);
            time += timeIntervalInPoints;
        }
    }
}
