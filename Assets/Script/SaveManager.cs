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

    private int slot1stage1star;
    private int slot1stage2star;
    private int slot1stage3star;
    private int slot1stage4star;

    private int slot2stage1star;
    private int slot2stage2star;
    private int slot2stage3star;
    private int slot2stage4star;

    private int slot3stage1star;
    private int slot3stage2star;
    private int slot3stage3star;
    private int slot3stage4star;

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
                PlayerPrefs.SetInt("slot1stage1star", dontDestroy.Stage1Score);
                PlayerPrefs.SetInt("slot1stage2star", dontDestroy.Stage2Score);
                PlayerPrefs.SetInt("slot1stage3star", dontDestroy.Stage3Score);
                PlayerPrefs.SetInt("slot1stage4star", dontDestroy.Stage4Score);
                isSlot1 = true;
               // PlayerPrefs.SetInt("Slot1", 1);
                time1 = System.DateTime.Now.ToString();
            }
            else if (SaveID.saveID == 2)
            {
                _StageID2 = dontDestroy.StageID;
                PlayerPrefs.SetInt("Stage" + SaveID.saveID, _StageID2);
                PlayerPrefs.SetString("Time" + SaveID.saveID, System.DateTime.Now.ToString());
                PlayerPrefs.SetInt("slot2stage1star", dontDestroy.Stage1Score);
                PlayerPrefs.SetInt("slot2stage2star", dontDestroy.Stage2Score);
                PlayerPrefs.SetInt("slot2stage3star", dontDestroy.Stage3Score);
                PlayerPrefs.SetInt("slot2stage4star", dontDestroy.Stage4Score);
                isSlot2 = true;
                //PlayerPrefs.SetInt("Slot2", 1);
                time2 = System.DateTime.Now.ToString();
            }
            else if (SaveID.saveID == 3)
            {
                _StageID3 = dontDestroy.StageID;
                PlayerPrefs.SetInt("Stage" + SaveID.saveID, _StageID3);
                PlayerPrefs.SetString("Time" + SaveID.saveID, System.DateTime.Now.ToString());
                PlayerPrefs.SetInt("slot3stage1star", dontDestroy.Stage1Score);
                PlayerPrefs.SetInt("slot3stage2star", dontDestroy.Stage2Score);
                PlayerPrefs.SetInt("slot3stage3star", dontDestroy.Stage3Score);
                PlayerPrefs.SetInt("slot3stage4star", dontDestroy.Stage4Score);
                isSlot3 = true;
                //PlayerPrefs.SetInt("Slot3", 1);
                time3 = System.DateTime.Now.ToString();
            }

        }
        
    }

    public void Load()
    {
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

        slot1stage1star = PlayerPrefs.GetInt("slot1stage1star");
        slot1stage2star = PlayerPrefs.GetInt("slot1stage2star");
        slot1stage3star = PlayerPrefs.GetInt("slot1stage3star");
        slot1stage4star = PlayerPrefs.GetInt("slot1stage4star");

        slot2stage1star = PlayerPrefs.GetInt("slot1stage1star");
        slot2stage2star = PlayerPrefs.GetInt("slot1stage2star");
        slot2stage3star = PlayerPrefs.GetInt("slot1stage3star");
        slot2stage4star = PlayerPrefs.GetInt("slot1stage4star");

        slot3stage1star = PlayerPrefs.GetInt("slot1stage1star");
        slot3stage2star = PlayerPrefs.GetInt("slot1stage2star");
        slot3stage3star = PlayerPrefs.GetInt("slot1stage3star");
        slot3stage4star = PlayerPrefs.GetInt("slot1stage4star");
    }

    public void OnClickLoad()
    {       
        if (SaveID.saveID == 1)
        {
            //if (_StageID1 == 0)
            //{
            //    _StageID1 = 1;
            //}
            if(isSlot1==true)
            {
                SceneManager.LoadScene("TestStageSelect");
                DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
                dontDestroy.StageID = _StageID1;
                dontDestroy.Stage1Score = slot1stage1star;
                dontDestroy.Stage2Score = slot1stage2star;
                dontDestroy.Stage3Score = slot1stage3star;
                dontDestroy.Stage4Score = slot1stage4star;
            }
           
        }
        else if (SaveID.saveID == 2)
        {
            //if (_StageID2 == 0)
            //{
            //    _StageID2 = 1;
            //}
            if (isSlot2 == true)
            {
                SceneManager.LoadScene("TestStageSelect");
                DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
                dontDestroy.StageID = _StageID2;
                dontDestroy.Stage1Score = slot2stage1star;
                dontDestroy.Stage2Score = slot2stage2star;
                dontDestroy.Stage3Score = slot2stage3star;
                dontDestroy.Stage4Score = slot2stage4star;
            }
        }
        else if (SaveID.saveID == 3)
        {
            //if (_StageID3 == 0)
            //{
            //    _StageID3 = 1;
            //}
            if (isSlot3 == true)
            {
                SceneManager.LoadScene("TestStageSelect");
                DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
                dontDestroy.Stage1Score = slot3stage1star;
                dontDestroy.Stage2Score = slot3stage2star;
                dontDestroy.Stage3Score = slot3stage3star;
                dontDestroy.Stage4Score = slot3stage4star;
                dontDestroy.StageID = _StageID3;
            }
        }
        
        
        //SceneManager.LoadScene("TestStageSelect");
    }

    public void OnClickDelete()
    {
        if (SaveID.saveID == 1)
        {
            PlayerPrefs.DeleteKey("Time1");
            PlayerPrefs.DeleteKey("Stage1");
            //_StageID1 = 0;
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = 0;
            dontDestroy.Stage1Score = 0;
            dontDestroy.Stage2Score = 0;
            dontDestroy.Stage3Score = 0;
            dontDestroy.Stage4Score = 0;
            isSlot1 = false;
        }
        else if (SaveID.saveID == 2)
        {
            PlayerPrefs.DeleteKey("Time2");
            PlayerPrefs.DeleteKey("Stage2");
            //_StageID2 = 0;
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = 0;
            dontDestroy.Stage1Score = 0;
            dontDestroy.Stage2Score = 0;
            dontDestroy.Stage3Score = 0;
            dontDestroy.Stage4Score = 0;
            isSlot2 = false;
        }
        else if (SaveID.saveID == 3)
        {
            PlayerPrefs.DeleteKey("Time3");
            PlayerPrefs.DeleteKey("Stage3");
            //_StageID3 = 0;
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            dontDestroy.StageID = 0;
            dontDestroy.Stage1Score = 0;
            dontDestroy.Stage2Score = 0;
            dontDestroy.Stage3Score = 0;
            dontDestroy.Stage4Score = 0;
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
