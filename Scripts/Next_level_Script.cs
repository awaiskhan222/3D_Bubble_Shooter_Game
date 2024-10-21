using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_level_Script : MonoBehaviour
{
    public GameObject win_panel;
    UI_BUTTON_SCRIPT UI_BUTTON_SCRIPT_CALL;

    private void Awake()
    {
        UI_BUTTON_SCRIPT_CALL = GameObject.FindGameObjectWithTag("ui_scirpt").GetComponent<UI_BUTTON_SCRIPT>();
    }
    private void Start()
    {
        UI_BUTTON_SCRIPT_CALL.resumebutton();
    }
    public void Next_level_BTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        win_panel.SetActive(false);
    }

    public void playButton(int n)
    {
        SceneManager.LoadScene(n);
        /*UI_BUTTON_SCRIPT_CALL.resumebutton();*/

    }
    public void Quit_btn()
    {
        Application.Quit();
    }

    public void Resume_btn()
    {
        UI_BUTTON_SCRIPT_CALL.resumebutton();
    }
    
}
