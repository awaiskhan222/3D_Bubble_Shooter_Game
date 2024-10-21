using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_ball_rotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1 * 30 * Time.deltaTime, 1 * 30 * Time.deltaTime, 1 * 30 * Time.deltaTime);

    }
}
