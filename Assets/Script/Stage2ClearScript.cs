using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2ClearScript : MonoBehaviour
{
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public GameObject nextBtn;

    private int count1;
    private int count2;
    private int count3;

    public AudioSource BGM;
    public AudioClip StageClear;

    [SerializeField]
    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
        nextBtn.SetActive(false);
        count1 = 0;
        count2 = 0;
        count3 = 0;
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
            SoundManager.instance.SFXPlay("StageClear", StageClear);
            Debug.Log("Clear");
            nextBtn.SetActive(true);
            //인벤1비교
            if (inventoryManager.interactionName1 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName1 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName1 == "cat")
            {
                count3 += 1;
            }
            //인벤2비교
            if (inventoryManager.interactionName2 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName2 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName2 == "cat")
            {
                count3 += 1;
            }
            //인벤3비교
            if (inventoryManager.interactionName3 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName3 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName3 == "cat")
            {
                count3 += 1;
            }
            //인벤4비교
            if (inventoryManager.interactionName4 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName4 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName4 == "cat")
            {
                count3 += 1;
            }

            //인벤5비교
            if (inventoryManager.interactionName5 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName5 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName5 == "cat")
            {
                count3 += 1;
            }

            //인벤6비교
            if (inventoryManager.interactionName6 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName6 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName6 == "cat")
            {
                count3 += 1;
            }
            //인벤7비교
            if (inventoryManager.interactionName7 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName7 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName7 == "cat")
            {
                count3 += 1;
            }
            //인벤8비교
            if (inventoryManager.interactionName8 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName8 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName8 == "cat")
            {
                count3 += 1;
            }
            //인벤9비교
            if (inventoryManager.interactionName9 == "봄_동상")
            {
                count1 += 1;
            }
            else if (inventoryManager.interactionName9 == "봄_안내판")
            {
                count2 += 1;
            }
            else if (inventoryManager.interactionName9 == "cat")
            {
                count3 += 1;
            }

            //총점계산
            if (count1 >= 1)
            {
                Score += 1;
            }

            if (count2 >= 1)
            {
                Score += 1;
            }

            if (count3 >= 1)
            {
                Score += 1;
            }

            if (Score == 1)
            {
                Star1.SetActive(true);
            }
            else if (Score == 2)
            {
                Star1.SetActive(true);
                Star2.SetActive(true);
            }
            else if (Score == 3)
            {
                Star1.SetActive(true);
                Star2.SetActive(true);
                Star3.SetActive(true);
            }

            Time.timeScale = 0f;
            DontDestroyOnLoad dontDestroy = FindObjectOfType<DontDestroyOnLoad>();
            if (dontDestroy.StageID < 3 && Score == 3)
            {
                dontDestroy.StageID = 3;
            }           
        }
    }

    public void OnClickNext()
    {
        SceneManager.LoadScene("TestStageSelect");
        Time.timeScale = 1f;
    }
}
