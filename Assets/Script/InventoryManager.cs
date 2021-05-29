using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private RenderTexture miniCam;

    [SerializeField]
    private RenderTexture renderTexture1;
    [SerializeField]
    private RenderTexture renderTexture2;
    [SerializeField]
    private RenderTexture renderTexture3;
    [SerializeField]
    private RenderTexture renderTexture4;
    [SerializeField]
    private RenderTexture renderTexture5;
    [SerializeField]
    private RenderTexture renderTexture6;
    [SerializeField]
    private RenderTexture renderTexture7;
    [SerializeField]
    private RenderTexture renderTexture8;
    [SerializeField]
    private RenderTexture renderTexture9;
    [SerializeField]
    private RenderTexture swapSlot;

    [HideInInspector]
    public string interactionName1;
    [HideInInspector]
    public string interactionName2;
    [HideInInspector]
    public string interactionName3;
    [HideInInspector]
    public string interactionName4;
    [HideInInspector]
    public string interactionName5;
    [HideInInspector]
    public string interactionName6;
    [HideInInspector]
    public string interactionName7;
    [HideInInspector]
    public string interactionName8;
    [HideInInspector]
    public string interactionName9;
    [HideInInspector]
    public string swapInteractionName;

    [SerializeField]
    private Image image1;
    [SerializeField]
    private Image image2;
    [SerializeField]
    private Image image3;

    [SerializeField]
    private RawImage rawImage1;
    [SerializeField]
    private RawImage rawImage2;
    [SerializeField]
    private RawImage rawImage3;

    [SerializeField]
    private int pictureWidth;
    [SerializeField]
    private int pictureHeight;

    private int pictureCount;

    [HideInInspector]
    public bool showInventory;

    [HideInInspector]
    public Texture2D screenShot;

    [HideInInspector]
    public bool isInteraction;

    private string wantName;
    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public bool modeChange;
 
    // Start is called before the first frame update
    void Start()
    {
        pictureCount = 0;
        renderTexture1.Release();
        renderTexture2.Release();
        renderTexture3.Release();
        renderTexture4.Release();
        renderTexture5.Release();
        renderTexture6.Release();
        renderTexture7.Release();
        renderTexture8.Release();
        renderTexture9.Release();
        swapSlot.Release();
        showInventory = false;

        interactionName1 = "null";
        interactionName2 = "null";
        interactionName3 = "null";
        interactionName4 = "null";
        interactionName5 = "null";
        interactionName6 = "null";
        interactionName7 = "null";
        interactionName8 = "null";
        interactionName9 = "null";
        swapInteractionName = "null";

        wantName = "null";

        isInteraction = false;
        isDead = false;
        modeChange = false;

    }

    // Update is called once per frame
    void Update()
    {
        Manager manager = FindObjectOfType<Manager>();
        InventoryManager inventory = FindObjectOfType<InventoryManager>();


        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            modeChange = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            modeChange = false;
        }

        if (manager.isPause == false)
        {
            if (Input.GetMouseButtonUp(0))
            {
                    if(modeChange == false)
                {
                    StartCoroutine("Capture");
                }
                   
               
                
            }

      


            if (showInventory == false)
            {
                image1.enabled = false;
                image2.enabled = false;
                image3.enabled = false;

                rawImage1.enabled = false;
                rawImage2.enabled = false;
                rawImage3.enabled = false;
            }


            if (showInventory == true)
            {
                image1.enabled = true;
                image2.enabled = true;
                image3.enabled = true;

                rawImage1.enabled = true;
                rawImage2.enabled = true;
                rawImage3.enabled = true;

                InteractionPicture();
                ChoicePicture();
                DeletePicture();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (showInventory == true)
                {
                    showInventory = false;
                }
                else
                {
                    showInventory = true;
                }
            }


        }
        if (manager.isPause == true)
        {
            StopCoroutine("Capture");
            StopCoroutine("PhantomCapture");
        }
        if (inventory.showInventory == true)
        {
            StopCoroutine("Capture");
            StopCoroutine("PhantomCapture");
        }

    }

    private void TakePicture(Texture2D screenShot, string interactionName)
    {
       

        if (pictureCount == 0)
        {
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName1 = interactionName;
        }
        else if (pictureCount == 1)
        {
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName2 = interactionName1;
            interactionName1 = interactionName;
        }
        else if (pictureCount == 2)
        {
            Graphics.Blit(renderTexture2, renderTexture9);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName9 = interactionName2;
            interactionName2 = interactionName1;
            interactionName1 = interactionName;
        }
        else if (pictureCount == 3)
        {
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName3 = interactionName2;
            interactionName2 = interactionName1;
            interactionName1 = interactionName;
        }
        else if (pictureCount == 4)
        {
            Graphics.Blit(renderTexture3, renderTexture4);
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName4 = interactionName3;
            interactionName3 = interactionName2;
            interactionName2 = interactionName1;
            interactionName1 = interactionName;
        }
        else if (pictureCount == 5)
        {
            Graphics.Blit(renderTexture4, renderTexture5);
            Graphics.Blit(renderTexture3, renderTexture4);
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName5 = interactionName4;
            interactionName4 = interactionName3;
            interactionName3 = interactionName2;
            interactionName2 = interactionName1;
            interactionName1 = interactionName;
        }
        else if (pictureCount == 6)
        {
            Graphics.Blit(renderTexture5, renderTexture6);
            Graphics.Blit(renderTexture4, renderTexture5);
            Graphics.Blit(renderTexture3, renderTexture4);
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName6 = interactionName5;
            interactionName5 = interactionName4;
            interactionName4 = interactionName3;
            interactionName3 = interactionName2;
            interactionName2 = interactionName1;
            interactionName1 = interactionName;
        }
        else if (pictureCount == 7)
        {
            Graphics.Blit(renderTexture6, renderTexture7);
            Graphics.Blit(renderTexture5, renderTexture6);
            Graphics.Blit(renderTexture4, renderTexture5);
            Graphics.Blit(renderTexture3, renderTexture4);
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName7 = interactionName6;
            interactionName6 = interactionName5;
            interactionName5 = interactionName4;
            interactionName4 = interactionName3;
            interactionName3 = interactionName2;
            interactionName2 = interactionName1;
            interactionName1 = interactionName;
        }
        else if (pictureCount == 8)
        {
            Graphics.Blit(renderTexture7, renderTexture8);
            Graphics.Blit(renderTexture6, renderTexture7);
            Graphics.Blit(renderTexture5, renderTexture6);
            Graphics.Blit(renderTexture4, renderTexture5);
            Graphics.Blit(renderTexture3, renderTexture4);
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;

            interactionName8 = interactionName7;
            interactionName7 = interactionName6;
            interactionName6 = interactionName5;
            interactionName5 = interactionName4;
            interactionName4 = interactionName3;
            interactionName3 = interactionName2;
            interactionName2 = interactionName1;
            interactionName1 = interactionName;
        }
    }

    private void DeletePicture()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (pictureCount > 3)
            {
                renderTexture1.Release();
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture4, renderTexture3);
                Graphics.Blit(renderTexture5, renderTexture4);
                Graphics.Blit(renderTexture6, renderTexture5);
                Graphics.Blit(renderTexture7, renderTexture6);
                Graphics.Blit(renderTexture8, renderTexture7);

                interactionName1 = "null";
                interactionName1 = interactionName2;
                interactionName2 = interactionName3;
                interactionName3 = interactionName4;
                interactionName4 = interactionName5;
                interactionName5 = interactionName6;
                interactionName6 = interactionName7;
                interactionName7 = interactionName8;
            }
            if (pictureCount <= 3)
            {
                renderTexture1.Release();
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture9, renderTexture2);
                renderTexture9.Release();

                interactionName1 = "null";
                interactionName1 = interactionName2;
                interactionName2 = interactionName9;
                interactionName9 = "null";
            }

            if (pictureCount > 0)
            {
                pictureCount -= 1;
            }


            swapSlot.Release();
            swapInteractionName = "null";
        }
    }

    private void InteractionPicture()
    {
        if (isInteraction == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (interactionName1 == wantName)
                {
                    isDead = true;
                    if (pictureCount > 3)
                    {
                        renderTexture1.Release();
                        Graphics.Blit(renderTexture2, renderTexture1);
                        Graphics.Blit(renderTexture3, renderTexture2);
                        Graphics.Blit(renderTexture4, renderTexture3);
                        Graphics.Blit(renderTexture5, renderTexture4);
                        Graphics.Blit(renderTexture6, renderTexture5);
                        Graphics.Blit(renderTexture7, renderTexture6);
                        Graphics.Blit(renderTexture8, renderTexture7);

                        interactionName1 = "null";
                        interactionName1 = interactionName2;
                        interactionName2 = interactionName3;
                        interactionName3 = interactionName4;
                        interactionName4 = interactionName5;
                        interactionName5 = interactionName6;
                        interactionName6 = interactionName7;
                        interactionName7 = interactionName8;
                    }
                    if (pictureCount <= 3)
                    {
                        renderTexture1.Release();
                        Graphics.Blit(renderTexture2, renderTexture1);
                        Graphics.Blit(renderTexture9, renderTexture2);
                        renderTexture9.Release();

                        interactionName1 = "null";
                        interactionName1 = interactionName2;
                        interactionName2 = interactionName9;
                        interactionName9 = "null";
                    }

                    if (pictureCount > 0)
                    {
                        pictureCount -= 1;
                    }


                    swapSlot.Release();
                    swapInteractionName = "null";
                }
                else
                {
                    //사진이 틀렸을때
                    Debug.Log("잘못된사진");
                }
            }

        }

    }

    private void ChoicePicture()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (pictureCount == 9)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture8, renderTexture9);
                Graphics.Blit(renderTexture7, renderTexture8);
                Graphics.Blit(renderTexture6, renderTexture7);
                Graphics.Blit(renderTexture5, renderTexture6);
                Graphics.Blit(renderTexture4, renderTexture5);
                Graphics.Blit(renderTexture3, renderTexture4);
                Graphics.Blit(renderTexture2, renderTexture3);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);

                swapInteractionName = interactionName9;
                interactionName9 = interactionName8;
                interactionName8 = interactionName7;
                interactionName7 = interactionName6;
                interactionName6 = interactionName5;
                interactionName5 = interactionName4;
                interactionName4 = interactionName3;
                interactionName3 = interactionName2;
                interactionName2 = interactionName1;
                interactionName1 = swapInteractionName;
            }
            else if (pictureCount == 8)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture7, renderTexture9);
                Graphics.Blit(renderTexture6, renderTexture7);
                Graphics.Blit(renderTexture5, renderTexture6);
                Graphics.Blit(renderTexture4, renderTexture5);
                Graphics.Blit(renderTexture3, renderTexture4);
                Graphics.Blit(renderTexture2, renderTexture3);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);

                swapInteractionName = interactionName9;
                interactionName9 = interactionName7;
                interactionName7 = interactionName6;
                interactionName6 = interactionName5;
                interactionName5 = interactionName4;
                interactionName4 = interactionName3;
                interactionName3 = interactionName2;
                interactionName2 = interactionName1;
                interactionName1 = swapInteractionName;
            }
            else if (pictureCount == 7)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture6, renderTexture9);
                Graphics.Blit(renderTexture5, renderTexture6);
                Graphics.Blit(renderTexture4, renderTexture5);
                Graphics.Blit(renderTexture3, renderTexture4);
                Graphics.Blit(renderTexture2, renderTexture3);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);

                swapInteractionName = interactionName9;
                interactionName9 = interactionName6;
                interactionName6 = interactionName5;
                interactionName5 = interactionName4;
                interactionName4 = interactionName3;
                interactionName3 = interactionName2;
                interactionName2 = interactionName1;
                interactionName1 = swapInteractionName;
            }
            else if (pictureCount == 6)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture5, renderTexture9);
                Graphics.Blit(renderTexture4, renderTexture5);
                Graphics.Blit(renderTexture3, renderTexture4);
                Graphics.Blit(renderTexture2, renderTexture3);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);

                swapInteractionName = interactionName9;
                interactionName9 = interactionName5;
                interactionName5 = interactionName4;
                interactionName4 = interactionName3;
                interactionName3 = interactionName2;
                interactionName2 = interactionName1;
                interactionName1 = swapInteractionName;
            }
            else if (pictureCount == 5)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture4, renderTexture9);
                Graphics.Blit(renderTexture3, renderTexture4);
                Graphics.Blit(renderTexture2, renderTexture3);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);

                swapInteractionName = interactionName9;
                interactionName9 = interactionName4;
                interactionName4 = interactionName3;
                interactionName3 = interactionName2;
                interactionName2 = interactionName1;
                interactionName1 = swapInteractionName;
            }
            else if (pictureCount == 4)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture3, renderTexture9);
                Graphics.Blit(renderTexture2, renderTexture3);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);

                swapInteractionName = interactionName9;
                interactionName9 = interactionName3;
                interactionName3 = interactionName2;
                interactionName2 = interactionName1;
                interactionName1 = swapInteractionName;
            }
            else if (pictureCount == 3)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture9);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);

                swapInteractionName = interactionName9;
                interactionName9 = interactionName2;
                interactionName2 = interactionName1;
                interactionName1 = swapInteractionName;
            }
            else if (pictureCount == 2)
            {
                Graphics.Blit(renderTexture2, swapSlot);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);

                swapInteractionName = interactionName2;
                interactionName2 = interactionName1;
                interactionName1 = swapInteractionName;
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pictureCount == 9)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture4, renderTexture3);
                Graphics.Blit(renderTexture5, renderTexture4);
                Graphics.Blit(renderTexture6, renderTexture5);
                Graphics.Blit(renderTexture7, renderTexture6);
                Graphics.Blit(renderTexture8, renderTexture7);
                Graphics.Blit(renderTexture9, renderTexture8);
                Graphics.Blit(swapSlot, renderTexture9);

                swapInteractionName = interactionName1;
                interactionName1 = interactionName2;
                interactionName2 = interactionName3;
                interactionName3 = interactionName4;
                interactionName4 = interactionName5;
                interactionName5 = interactionName6;
                interactionName6 = interactionName7;
                interactionName7 = interactionName8;
                interactionName8 = interactionName9;
                interactionName9 = swapInteractionName;
            }
            else if (pictureCount == 8)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture4, renderTexture3);
                Graphics.Blit(renderTexture5, renderTexture4);
                Graphics.Blit(renderTexture6, renderTexture5);
                Graphics.Blit(renderTexture7, renderTexture6);
                Graphics.Blit(renderTexture9, renderTexture7);
                Graphics.Blit(swapSlot, renderTexture9);

                swapInteractionName = interactionName1;
                interactionName1 = interactionName2;
                interactionName2 = interactionName3;
                interactionName3 = interactionName4;
                interactionName4 = interactionName5;
                interactionName5 = interactionName6;
                interactionName6 = interactionName7;
                interactionName7 = interactionName9;
                interactionName9 = swapInteractionName;
            }
            else if (pictureCount == 7)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture4, renderTexture3);
                Graphics.Blit(renderTexture5, renderTexture4);
                Graphics.Blit(renderTexture6, renderTexture5);
                Graphics.Blit(renderTexture9, renderTexture6);
                Graphics.Blit(swapSlot, renderTexture9);

                swapInteractionName = interactionName1;
                interactionName1 = interactionName2;
                interactionName2 = interactionName3;
                interactionName3 = interactionName4;
                interactionName4 = interactionName5;
                interactionName5 = interactionName6;
                interactionName6 = interactionName9;
                interactionName9 = swapInteractionName;
            }
            else if (pictureCount == 6)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture4, renderTexture3);
                Graphics.Blit(renderTexture5, renderTexture4);
                Graphics.Blit(renderTexture9, renderTexture5);
                Graphics.Blit(swapSlot, renderTexture9);

                swapInteractionName = interactionName1;
                interactionName1 = interactionName2;
                interactionName2 = interactionName3;
                interactionName3 = interactionName4;
                interactionName4 = interactionName5;
                interactionName5 = interactionName9;
                interactionName9 = swapInteractionName;
            }
            else if (pictureCount == 5)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture4, renderTexture3);
                Graphics.Blit(renderTexture9, renderTexture4);
                Graphics.Blit(swapSlot, renderTexture9);

                swapInteractionName = interactionName1;
                interactionName1 = interactionName2;
                interactionName2 = interactionName3;
                interactionName3 = interactionName4;
                interactionName4 = interactionName9;
                interactionName9 = swapInteractionName;
            }
            else if (pictureCount == 4)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture9, renderTexture3);
                Graphics.Blit(swapSlot, renderTexture9);

                swapInteractionName = interactionName1;
                interactionName1 = interactionName2;
                interactionName2 = interactionName3;
                interactionName3 = interactionName9;
                interactionName9 = swapInteractionName;
            }
            else if (pictureCount == 3)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture9, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture9);

                swapInteractionName = interactionName1;
                interactionName1 = interactionName2;
                interactionName2 = interactionName9;
                interactionName9 = swapInteractionName;
            }
            else if (pictureCount == 2)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(swapSlot, renderTexture2);

                swapInteractionName = interactionName1;
                interactionName1 = interactionName2;
                interactionName2 = swapInteractionName;
            }

        }
    }

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
        //screenShot = new Texture2D(pictureWidth, pictureHeight, TextureFormat.RGB24, false);
        //screenShot.ReadPixels(new Rect(Input.mousePosition.x  - pictureWidth / 2, Input.mousePosition.y  - pictureHeight / 2, pictureWidth, pictureHeight), 0, 0, false);
        //screenShot.Apply();

        screenShot = new Texture2D(miniCam.width, miniCam.height, TextureFormat.RGB24, false);
        RenderTexture.active = miniCam;
        screenShot.ReadPixels(new Rect(0, 0, miniCam.width, miniCam.height), 0, 0, false);
        screenShot.Apply();

        RenderTexture.active = null;

        interactionManager interactionMgr = FindObjectOfType<interactionManager>();


        TakePicture(screenShot, interactionMgr.interactionName);
    }
  


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interaction")
        {
            isInteraction = true;
            wantName = other.gameObject.transform.GetComponent<InteractionObj>().wantName;
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interaction")
        {
            isInteraction = false;
            wantName = "null";
        }
    }
}


   




