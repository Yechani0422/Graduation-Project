using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StageChange : MonoBehaviour
{
    public GameObject Spring;
    public GameObject Summer;
    public GameObject Fall;
    public GameObject Winter;

    public GameObject stage1star1;
    public GameObject stage1star2;
    public GameObject stage1star3;

    public GameObject stage2star1;
    public GameObject stage2star2;
    public GameObject stage2star3;

    public GameObject stage3star1;
    public GameObject stage3star2;
    public GameObject stage3star3;

    public GameObject stage4star1;
    public GameObject stage4star2;
    public GameObject stage4star3;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        if(dontDestroy.StageID==0)
        {
            dontDestroy.StageID = 1;
        }
        
        GameObject dont = GameObject.FindGameObjectWithTag("DontDestroy");
        AudioSource soundOff = dont.GetComponent<AudioSource>();

        soundOff.Stop();
        
        Spring.SetActive(false);
        Summer.SetActive(false);
        Fall.SetActive(false);
        Winter.SetActive(true);

        stage1star1.SetActive(false);
        stage1star2.SetActive(false);
        stage1star3.SetActive(false);

        stage2star1.SetActive(false);
        stage2star2.SetActive(false);
        stage2star3.SetActive(false);

        stage3star1.SetActive(false);
        stage3star2.SetActive(false);
        stage3star3.SetActive(false);

        stage4star1.SetActive(false);
        stage4star2.SetActive(false);
        stage4star3.SetActive(false);

        Debug.Log("Stage1"+dontDestroy.Stage1Score);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeStage();
       
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (Spring.activeSelf == true)
                {
                    OnClickSpring();
                    EventSystem.current.SetSelectedGameObject(Spring);
                }
                else if (Summer.activeSelf == true)
                {
                    OnClickSummer();
                    EventSystem.current.SetSelectedGameObject(Summer);
                }
                else if(Fall.activeSelf == true)
                {
                    OnClickFall();
                    EventSystem.current.SetSelectedGameObject(Fall);
                }
                else if(Winter.activeSelf == true)
                {
                    OnClickWinter();
                    EventSystem.current.SetSelectedGameObject(Winter);
                }
            }

        StarManager();
    }

    void StarManager()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();

        //stage1
        if(Winter.activeSelf==true)
        {
            if (dontDestroy.Stage1Score == 1)
            {
                stage1star1.SetActive(true);
            }
            else if (dontDestroy.Stage1Score == 2)
            {
                stage1star1.SetActive(true);
                stage1star2.SetActive(true);
            }
            else if (dontDestroy.Stage1Score == 3)
            {
                stage1star1.SetActive(true);
                stage1star2.SetActive(true);
                stage1star3.SetActive(true);
            }
        }


        //stage2
        if (Spring.activeSelf == true)
        {
            if (dontDestroy.Stage2Score == 1)
            {
                stage2star1.SetActive(true);
            }
            else if (dontDestroy.Stage2Score == 2)
            {
                stage2star1.SetActive(true);
                stage2star2.SetActive(true);
            }
            else if (dontDestroy.Stage2Score == 3)
            {
                stage2star1.SetActive(true);
                stage2star2.SetActive(true);
                stage2star3.SetActive(true);
            }
        }

        //stage3
        if (Summer.activeSelf == true)
        {
            if (dontDestroy.Stage3Score == 1)
            {
                stage3star1.SetActive(true);
            }
            else if (dontDestroy.Stage3Score == 2)
            {
                stage3star1.SetActive(true);
                stage3star2.SetActive(true);
            }
            else if (dontDestroy.Stage3Score == 3)
            {
                stage3star1.SetActive(true);
                stage3star2.SetActive(true);
                stage3star3.SetActive(true);
            }
        }

        //stage4
        if (Fall.activeSelf == true)
        {
            if (dontDestroy.Stage4Score == 1)
            {
                stage4star1.SetActive(true);
            }
            else if (dontDestroy.Stage4Score == 2)
            {
                stage4star1.SetActive(true);
                stage4star2.SetActive(true);
            }
            else if (dontDestroy.Stage4Score == 3)
            {
                stage4star1.SetActive(true);
                stage4star2.SetActive(true);
                stage4star3.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    private void ChangeStage()
    {
       
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(Spring.activeSelf==true)
                {
                    Spring.SetActive(false);
                    Summer.SetActive(true);
                }
                else if(Summer.activeSelf==true)
                {
                    Summer.SetActive(false);
                    Fall.SetActive(true);
                }
                else if(Fall.activeSelf==true)
                {
                    Fall.SetActive(false);
                    Winter.SetActive(true);
                }
                else if(Winter.activeSelf==true)
                {
                    Winter.SetActive(false);
                    Spring.SetActive(true);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (Spring.activeSelf == true)
                {
                    Spring.SetActive(false);
                    Winter.SetActive(true);
                }
                else if (Winter.activeSelf == true)
                {
                    Winter.SetActive(false);
                    Fall.SetActive(true);
                }
                else if (Fall.activeSelf == true)
                {
                    Fall.SetActive(false);
                    Summer.SetActive(true);
                }
                else if (Summer.activeSelf == true)
                {
                    Summer.SetActive(false);
                    Spring.SetActive(true);
                }
            }
        
    }

    public void OnClickLeft()
    {
        
            if (Spring.activeSelf == true)
            {
                Spring.SetActive(false);
                Winter.SetActive(true);
            }
            else if (Winter.activeSelf == true)
            {
                Winter.SetActive(false);
                Fall.SetActive(true);
            }
            else if (Fall.activeSelf == true)
            {
                Fall.SetActive(false);
                Summer.SetActive(true);
            }
            else if (Summer.activeSelf == true)
            {
                Summer.SetActive(false);
                Spring.SetActive(true);
            }
        
    }

    public void OnClickRight()
    {

        if (Spring.activeSelf == true)
        {
            Spring.SetActive(false);
            Summer.SetActive(true);
        }
        else if (Summer.activeSelf == true)
        {
            Summer.SetActive(false);
            Fall.SetActive(true);
        }
        else if (Fall.activeSelf == true)
        {
            Fall.SetActive(false);
            Winter.SetActive(true);
        }
        else if (Winter.activeSelf == true)
        {
            Winter.SetActive(false);
            Spring.SetActive(true);
        }

    }

    public void OnClickSpring()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        if (dontDestroy.StageID >= 2)
        {
            SceneManager.LoadScene("SpringStage");
        }
    }

    public void OnClickSummer()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        if (dontDestroy.StageID >= 3)
        {
            SceneManager.LoadScene("WinterStage2");
        }
    }

    public void OnClickFall()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        if (dontDestroy.StageID >= 4)
        {
            SceneManager.LoadScene("SpringStage2");
        }
    }

    public void OnClickWinter()
    {
        SceneManager.LoadScene("WinterStage");
    }

    public void OnClickSave()
    {
        SceneManager.LoadScene("SaveLoad");
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
