using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button NewGame;
    public Button Continue;
    public Button Help;
    public Button Quit;
    public Button Back;

    public Image title;
    public Image helpImage1;
    public Image helpImage2;

    public Button LoadButton1;
    public Button LoadButton2;
    public Button LoadButton3;



    public void OnclickNewGameBtn()
    {
        SceneManager.LoadScene("WinterStage");
    }

    public void OnclickContinueBtn()
    {
        NewGame.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
        Help.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        Back.gameObject.SetActive(true);
        LoadButton1.gameObject.SetActive(true);
        LoadButton2.gameObject.SetActive(true);
        LoadButton3.gameObject.SetActive(true);
    }

    public void OnclickHelpBtn()
    {
        NewGame.gameObject.SetActive(false);
        Continue.gameObject.SetActive(false);
        Help.gameObject.SetActive(false);
        Quit.gameObject.SetActive(false);
        Back.gameObject.SetActive(true);
        helpImage1.enabled = true;
        helpImage2.enabled = true;
        title.enabled = false;
    }

    public void OnclickQuitBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
      
    }

    public void OnclickBackBtn()
    {
        NewGame.gameObject.SetActive(true);
        Continue.gameObject.SetActive(true);
        Help.gameObject.SetActive(true);
        Quit.gameObject.SetActive(true);
        LoadButton1.gameObject.SetActive(false);
        LoadButton2.gameObject.SetActive(false);
        LoadButton3.gameObject.SetActive(false);
        Back.gameObject.SetActive(false);
        title.enabled = true;
        helpImage1.enabled = false;
        helpImage2.enabled = false;


    }
}
