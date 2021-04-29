using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject SubMenu;
    [HideInInspector]
    public bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        SubMenu.SetActive(false);
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SubMenu.activeSelf==true)
            {
                SubMenu.SetActive(false);
                isPause = false;
                Time.timeScale = 1f;
            }
            else
            {
                SubMenu.SetActive(true);
                isPause = true;
                Time.timeScale = 0f;
            }           
        }
    }

    public void OnClickResume()
    {
        SubMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickSave()
    {
        SceneManager.LoadScene("SaveLoad");
        //DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        //PlayerPrefs.SetInt("Stage", dontDestroy.StageID);
        Time.timeScale = 1f;
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
