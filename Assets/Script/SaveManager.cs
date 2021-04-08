using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public int _StageID;
    private bool isSlot;

    public Text LoadButton;
    public string time = "----";

    // Start is called before the first frame updat
    
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSlot==true)
        {
            LoadButton.text = time + "||" + _StageID.ToString();
        }
        else if(isSlot==false)
        {
            if(!PlayerPrefs.HasKey("Time"))
            {
                LoadButton.text = "New Game";
            }
        }
       
    }

    public void OnClickSave()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
       
                
        if(dontDestroy.StageID!=0)
        {
            _StageID = dontDestroy.StageID;
            PlayerPrefs.SetString("Time", System.DateTime.Now.ToString());
            PlayerPrefs.SetInt("Stage", _StageID);
            time = System.DateTime.Now.ToString();
            Debug.Log(_StageID);
            isSlot = true;
        }
        
    }

    public void Load()
    {
        if (!PlayerPrefs.HasKey("Stage"))
        {
            _StageID = 1;
            return;
        }

        if(PlayerPrefs.HasKey("Time"))
        {
            isSlot = true;
        }
        time = PlayerPrefs.GetString("Time");
        _StageID = PlayerPrefs.GetInt("Stage");
    }

    public void OnClickLoad()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        if(_StageID==0)
        {
            _StageID = 1;
        }
        dontDestroy.StageID = _StageID;
        SceneManager.LoadScene("TestStageSelect");
    }

    public void OnClickDelete()
    {
        PlayerPrefs.DeleteAll();
        _StageID = 0;
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        dontDestroy.StageID = 0;
        isSlot = false;
    }
}
