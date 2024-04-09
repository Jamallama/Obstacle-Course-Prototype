using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
Spidergram
Alejandro Jauco
4/11/2023
5/24/2023 Added timeScale=1 fix to PlayScene() and OnDestroy()
*/


public class PauseMenu : MonoBehaviour
{
    // public string button = "Cancel";
    [Tooltip("Go to SceneNum level or if gMenu then display the menu")]
    public KeyCode LevelExit = KeyCode.Delete;  // leave the current level.  Go to SceneNum
    public int SceneNum = 0;

    [Tooltip("Quit the app if standalone build")]
    public KeyCode quitkey = KeyCode.Q;  // leave the complete app. Used for standalone build

    [Tooltip("Used for open a menu if available")]
    public GameObject gMenu; // gameobject that will be enabled if available


    bool toggleMenu = false;

    public bool hideCursorAtStart = true;

    void Awake()
    {
        Debug.Log("TimeScale " + Time.timeScale);
        // Time.timeScale = 1f;

        toggleMenu = false;
        if (gMenu != null)
            gMenu.gameObject.SetActive(toggleMenu);

        if (hideCursorAtStart)
            HideCursor();

    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
        Debug.Log("OnDestroy TimeScale " + Time.timeScale);

    }

    void CheckAppQuit()
    {
#if UNITY_STANDALONE
        if (Input.GetKeyDown(quitkey))
        {
            Debug.Log("Quit App");
            Time.timeScale = 1.0f;
            ShowCursor();
            Application.Quit();
        }
#endif
    }

    GameObject player;
    void ShowMenu()
    {

        toggleMenu = !toggleMenu;
        gMenu.gameObject.SetActive(toggleMenu);
        Time.timeScale = (toggleMenu)? 0f : 1f;
        if (toggleMenu)  // menu is showing
        {
            ShowCursor();

            player = GameObject.FindWithTag("Player");
            if (player != null)
                player.gameObject.SetActive(false);
        }
        else
        {
            //GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                player.gameObject.SetActive(true);

            HideCursor();
        }


    }

    void CheckLeaveLevel()
    {
        if (Input.GetKeyDown(LevelExit))
        {

            if (gMenu != null)
            {
                ShowMenu();
                return;
            }

            Debug.Log("Leave the Level");
            Time.timeScale = 1.0f;
            ShowCursor();
            PlayScene();
        }
    }


    public void PlayScene()
    {
        Time.timeScale = 1f;
        Debug.Log("PlayScene TimeScale " + Time.timeScale);
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneNum);

        //Debug.Log("Call Scene: " + SceneNum);
    }
    public void ShowCursor()
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Show Cursor " + Cursor.visible.ToString());
    }
    public void HideCursor()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("Hide Cursor");
    }


    // Update is called once per frame
    void Update()
    {

        CheckAppQuit();
        CheckLeaveLevel();
        return;
        /*
        if (Input.GetButtonDown(button))
        {
            ShowCursor();
            PlayScene();
            //SceneManager.LoadScene(SceneName);
            //Debug.Log("Call Scene: " + SceneName);
        }
        */
    }
}
