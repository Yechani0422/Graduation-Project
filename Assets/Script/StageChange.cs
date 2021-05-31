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
    
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        if(dontDestroy.StageID==0)
        {
            dontDestroy.StageID = 1;
        }
        
        Spring.SetActive(false);
        Summer.SetActive(false);
        Fall.SetActive(false);
        Winter.SetActive(true);
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
           
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    private void ChangeStage()
    {
       
            if (Input.GetKeyDown(KeyCode.UpArrow))
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

            if (Input.GetKeyDown(KeyCode.DownArrow))
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

    public void OnClickSpring()
    {
        DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
        if (dontDestroy.StageID >= 2)
        {
            SceneManager.LoadScene("TestScene2");
        }
    }

    public void OnClickSummer()
    {
       // SceneManager.LoadScene("TestStageSelect");
    }

    public void OnClickFall()
    {
        
    }

    public void OnClickWinter()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
