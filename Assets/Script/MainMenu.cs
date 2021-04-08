using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickNEW()
    {
        Debug.Log("NEW");
        SceneManager.LoadScene("TestStageSelect");
    }
    public void OnclickLOAD()
    {
        Debug.Log("LOAD");
        SceneManager.LoadScene("SaveLoad");
    }
    public void OnclickQUIT()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("QUIT");
#else
            Application.Quit();
#endif

    }
}
