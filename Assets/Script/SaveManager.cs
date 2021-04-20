using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private int _StageID1;
    private int _StageID2;
    private int _StageID3;

    private bool isSlot1;
    private bool isSlot2;
    private bool isSlot3;

    public Text LoadButton1;
    public Text LoadButton2;
    public Text LoadButton3;

    private string time1;
    private string time2;
    private string time3;

    // Start is called before the first frame updat

    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        //1
        if(isSlot1==true)
        {
            LoadButton1.text = time1 + " 스테이지:" + _StageID1.ToString();
        }
        else if(isSlot1==false)
        {
            if(!PlayerPrefs.HasKey("Time"))
            {
                LoadButton1.text = "New Game";
            }
        }

        //2
        if (isSlot2 == true)
        {
            LoadButton2.text = time2 + " 스테이지:" + _StageID2.ToString();
        }
        else if (isSlot2 == false)
        {
            if (!PlayerPrefs.HasKey("Time"))
            {
                LoadButton2.text = "New Game";
            }
        }

        //3
        if (isSlot3 == true)
        {
            LoadButton3.text = time3 + " 스테이지:" + _StageID3.ToString();
        }
        else if (isSlot3 == false)
        {
            if (!PlayerPrefs.HasKey("Time"))
            {
                LoadButton3.text = "New Game";
            }
        }
    }

    public void OnClickSave()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
       
                
        if(dontDestroy.StageID!=0)
        {                 
            if(SaveID.saveID==1)
            {
                _StageID1 = dontDestroy.StageID;
                PlayerPrefs.SetInt("Stage" + SaveID.saveID, _StageID1);
                PlayerPrefs.SetString("Time" + SaveID.saveID, System.DateTime.Now.ToString());
                isSlot1 = true;
               // PlayerPrefs.SetInt("Slot1", 1);
                time1 = System.DateTime.Now.ToString();
            }
            else if (SaveID.saveID == 2)
            {
                _StageID2 = dontDestroy.StageID;
                PlayerPrefs.SetInt("Stage" + SaveID.saveID, _StageID2);
                PlayerPrefs.SetString("Time" + SaveID.saveID, System.DateTime.Now.ToString());
                isSlot2 = true;
                //PlayerPrefs.SetInt("Slot2", 1);
                time2 = System.DateTime.Now.ToString();
            }
            else if (SaveID.saveID == 3)
            {
                _StageID3 = dontDestroy.StageID;
                PlayerPrefs.SetInt("Stage" + SaveID.saveID, _StageID3);
                PlayerPrefs.SetString("Time" + SaveID.saveID, System.DateTime.Now.ToString());
                isSlot3 = true;
                //PlayerPrefs.SetInt("Slot3", 1);
                time3 = System.DateTime.Now.ToString();
            }

        }
        
    }

    public void Load()
    {

        if (!PlayerPrefs.HasKey("Stage1"))
        {
            _StageID1 = 1;
            //return;
        }

        if (!PlayerPrefs.HasKey("Stage2"))
        {
            _StageID2 = 1;
            //return;
        }

        if (!PlayerPrefs.HasKey("Stage3"))
        {
            _StageID3 = 1;
            //return;
        }

        if (PlayerPrefs.HasKey("Time1"))
        {
            isSlot1 = true;
        }

        if (PlayerPrefs.HasKey("Time2"))
        {
            isSlot2 = true;
        }

        if (PlayerPrefs.HasKey("Time3"))
        {
            isSlot3 = true;
        }

        time1 = PlayerPrefs.GetString("Time1");
        time2 = PlayerPrefs.GetString("Time2");
        time3 = PlayerPrefs.GetString("Time3");

        _StageID1 = PlayerPrefs.GetInt("Stage1");
        _StageID2 = PlayerPrefs.GetInt("Stage2");
        _StageID3 = PlayerPrefs.GetInt("Stage3");
    }

    public void OnClickLoad()
    {       
        if (SaveID.saveID == 1)
        {
            if (_StageID1 == 0)
            {
                _StageID1 = 1;
            }
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = _StageID1;
        }
        else if (SaveID.saveID == 2)
        {
            if (_StageID2 == 0)
            {
                _StageID2 = 1;
            }
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = _StageID2;
        }
        else if (SaveID.saveID == 3)
        {
            if (_StageID3 == 0)
            {
                _StageID3 = 1;
            }
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = _StageID3;
        }
        
        
        SceneManager.LoadScene("TestStageSelect");
    }

    public void OnClickDelete()
    {
        if (SaveID.saveID == 1)
        {
            PlayerPrefs.DeleteKey("Time1");
            PlayerPrefs.DeleteKey("Stage1");
            _StageID1 = 0;
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = 0;
            isSlot1 = false;
        }
        else if (SaveID.saveID == 2)
        {
            PlayerPrefs.DeleteKey("Time2");
            PlayerPrefs.DeleteKey("Stage2");
            _StageID2 = 0;
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = 0;
            isSlot2 = false;
        }
        else if (SaveID.saveID == 3)
        {
            PlayerPrefs.DeleteKey("Time3");
            PlayerPrefs.DeleteKey("Stage3");
            _StageID3 = 0;
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = 0;
            isSlot3 = false;
        }       
        
        
       
        
    }

    public void SetSaveID(int saveID)
    {
        SaveID.saveID = saveID;
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
