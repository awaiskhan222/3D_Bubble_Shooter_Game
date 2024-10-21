using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI_BUTTON_SCRIPT : MonoBehaviour
{
    public GameObject pause_panel;
    public GameObject pause_btn;
    public GameObject UI_ppanel;

    Player_Script player_script;
    Ball_Motion_Script ball_motion_script;
    Camera_Rotation camera_rotation;
    private void Start()
    {
        player_script = GameObject.FindGameObjectWithTag("playerscript").GetComponent<Player_Script>();
        ball_motion_script = GameObject.FindGameObjectWithTag("player").GetComponent <Ball_Motion_Script>();
        camera_rotation = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Rotation>();
    }
    public void pausbutton()
    {
        pause_panel.SetActive(true);
        UI_ppanel.SetActive(false);
        /*pause_btn.SetActive(false);*/
        Time.timeScale = 0f;
        player_script.enabled = false;
        ball_motion_script.enabled = false;
        camera_rotation.enabled = false;
    }

    public void resumebutton()
    {
        UI_ppanel.SetActive(true);
        pause_panel.SetActive(false);
        /*pause_btn.SetActive(true);*/
        Time.timeScale = 1f;

        Invoke("plaerscript_fun", 1f);
    }

    public void restartbutton(int n)
    {
        SceneManager.LoadScene(n);
    }

    public void Quit_Fun()
    {
        Application.Quit();
    }

    public void Menu_button(int n)
    {
        SceneManager.LoadScene(n);
    }

    void plaerscript_fun()
    {
        player_script.enabled = true;
        camera_rotation.enabled = true;
        ball_motion_script.enabled = true;
    }
}
