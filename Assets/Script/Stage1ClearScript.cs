using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1ClearScript : MonoBehaviour
{
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject nextBtn;
    public GameObject BG;

    public AudioSource BGM;
    public AudioClip StageClear;
    private int fishBread;
    private int snowMan;
    private int cat;

    [SerializeField]
    private InventoryManager inventoryManager;

    
    // Start is called before the first frame update
    void Start()
    {
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        nextBtn.SetActive(false);
        BG.SetActive(false);
        fishBread = 0;
        snowMan = 0;
        cat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int Score = 0;

        if (other.gameObject.tag == "Player")
        {
            AudioSource.Destroy(BGM);
            Debug.Log("Clear");
            SoundManager.instance.SFXPlay("StageClear", StageClear);
            nextBtn.SetActive(true);
            BG.SetActive(true);
            //인벤1비교
            if (inventoryManager.interactionName1 == "붕어빵")
            {
                fishBread += 1;
            }
            else if(inventoryManager.interactionName1=="눈사람")
            {
                snowMan += 1;
            }
            else if(inventoryManager.interactionName1=="cat")
            {
                cat += 1;
            }
            //인벤2비교
            if (inventoryManager.interactionName2 == "붕어빵")
            {
                fishBread += 1;
            }
            else if (inventoryManager.interactionName2 == "눈사람")
            {
                snowMan += 1;
            }
            else if (inventoryManager.interactionName2 == "cat")
            {
                cat += 1;
            }
            //인벤3비교
            if (inventoryManager.interactionName3 == "붕어빵")
            {
                fishBread += 1;
            }
            else if (inventoryManager.interactionName3 == "눈사람")
            {
                snowMan += 1;
            }
            else if (inventoryManager.interactionName3 == "cat")
            {
                cat += 1;
            }
            //인벤4비교
            if (inventoryManager.interactionName4 == "붕어빵")
            {
                fishBread += 1;
            }
            else if (inventoryManager.interactionName4 == "눈사람")
            {
                snowMan += 1;
            }
            else if (inventoryManager.interactionName4 == "cat")
            {
                cat += 1;
            }

            //인벤5비교
            if (inventoryManager.interactionName5 == "붕어빵")
            {
                fishBread += 1;
            }
            else if (inventoryManager.interactionName5 == "눈사람")
            {
                snowMan += 1;
            }
            else if (inventoryManager.interactionName5 == "cat")
            {
                cat += 1;
            }

            //인벤6비교
            if (inventoryManager.interactionName6 == "붕어빵")
            {
                fishBread += 1;
            }
            else if (inventoryManager.interactionName6 == "눈사람")
            {
                snowMan += 1;
            }
            else if (inventoryManager.interactionName6 == "cat")
            {
                cat += 1;
            }
            //인벤7비교
            if (inventoryManager.interactionName7 == "붕어빵")
            {
                fishBread += 1;
            }
            else if (inventoryManager.interactionName7 == "눈사람")
            {
                snowMan += 1;
            }
            else if (inventoryManager.interactionName7 == "cat")
            {
                cat += 1;
            }
            //인벤8비교
            if (inventoryManager.interactionName8 == "붕어빵")
            {
                fishBread += 1;
            }
            else if (inventoryManager.interactionName8 == "눈사람")
            {
                snowMan += 1;
            }
            else if (inventoryManager.interactionName8 == "cat")
            {
                cat += 1;
            }
            //인벤9비교
            if (inventoryManager.interactionName9 == "붕어빵")
            {
                fishBread += 1;
            }
            else if (inventoryManager.interactionName9 == "눈사람")
            {
                snowMan += 1;
            }
            else if (inventoryManager.interactionName9 == "cat")
            {
                cat += 1;
            }

            //총점계산
            if(fishBread>=1)
            {
                Score += 1;
            }
            
            if(snowMan>=1)
            {
                Score += 1;
            }

            if(cat>=1)
            {
                Score += 1;
            }

            if(Score==1)
            {
                Star1.SetActive(true);
            }
            else if(Score==2)
            {
                Star1.SetActive(true);
                Star2.SetActive(true);
            }
            else if(Score==3)
            {
                Star1.SetActive(true);
                Star2.SetActive(true);
                Star3.SetActive(true);
            }

            Time.timeScale = 0f;
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();

            if(dontDestroy.Stage1Score<3&&Score==3)//star3
            {
                dontDestroy.Stage1Score = Score;
            }

            if(dontDestroy.Stage1Score<2&&Score==2)//star2
            {
                dontDestroy.Stage1Score = Score;
            }

            if(dontDestroy.Stage1Score<1&&Score==1)//star1
            {
                dontDestroy.Stage1Score = Score;
            }
            
            if (dontDestroy.StageID < 2 && Score == 3)
            {
                dontDestroy.StageID = 2;
            }
        }
    }

    public void OnClickNext()
    {
        SceneManager.LoadScene("TestStageSelect");
        Time.timeScale = 1f;
    }
}
