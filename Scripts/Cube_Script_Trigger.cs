using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Script_Trigger : MonoBehaviour
{
    /*public GameObject UI_trigger_panel;*/
    public Transform refrence; // The parent reference where balls will be parented
    private GameObject currentBall; // Track the currently parented ball

    private void OnTriggerEnter(Collider other)
    {
        // If the object entering the trigger is tagged as "player"
        if (other.gameObject.tag == "player")
        {
            /*UI_trigger_panel.SetActive(true);*/

            // If no ball is currently parented or another ball entered
            if (currentBall == null || currentBall != other.gameObject)
            {
                // Unparent the old ball if it exists
                if (currentBall != null)
                {
                    currentBall.transform.SetParent(null);
                }

                // Set the new ball as the current ball
                currentBall = other.gameObject;

                // Make the new ball a child of the reference
                currentBall.transform.SetParent(refrence);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When a ball exits, check if it's the current ball
        if (other.gameObject.tag == "player" && currentBall == other.gameObject)
        {
            // Unparent the ball that exited
            currentBall.transform.SetParent(null);

            // Deactivate UI since the player ball exited the trigger
            /*UI_trigger_panel.SetActive(false);*/

            // Clear the reference to the current ball
            currentBall = null;
        }
    }
}
