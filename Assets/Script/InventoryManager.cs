using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

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
    private bool showInventory;

    [HideInInspector]
    public Texture2D screenShot;
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
    }

    // Update is called once per frame
    void Update()
    {
        Manager manager = FindObjectOfType<Manager>();

        if(manager.isPause==false)
        {
            if (Input.GetMouseButtonUp(0))
            {
                screenShot = new Texture2D(pictureWidth, pictureHeight, TextureFormat.RGB24, false);
                screenShot.ReadPixels(new Rect(Input.mousePosition.x + 10 - pictureWidth / 2, Input.mousePosition.y - 10 - pictureHeight / 2, pictureWidth, pictureHeight), 0, 0, false);
                screenShot.Apply();

                TakePicture(screenShot);
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
        
        
    }

    private void TakePicture(Texture2D screenShot)
    {
        if(pictureCount == 0)
        {
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;
        }
        else if(pictureCount == 1)
        {
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;
        }
        else if(pictureCount == 2)
        {
            Graphics.Blit(renderTexture2, renderTexture9);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;
        }
        else if (pictureCount == 3)
        {
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;
        }
        else if (pictureCount == 4)
        {
            Graphics.Blit(renderTexture3, renderTexture4);
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;
        }
        else if (pictureCount == 5)
        {
            Graphics.Blit(renderTexture4, renderTexture5);
            Graphics.Blit(renderTexture3, renderTexture4);
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;
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
            }
            if (pictureCount <= 3)
            {
                renderTexture1.Release();
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture9, renderTexture2);
                renderTexture9.Release();
            }

            if (pictureCount > 0)
            {
                pictureCount -= 1;
            }


            swapSlot.Release();
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
            }
            else if (pictureCount == 5)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture4, renderTexture9);
                Graphics.Blit(renderTexture3, renderTexture4);
                Graphics.Blit(renderTexture2, renderTexture3);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);
            }
            else if (pictureCount == 4)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture3, renderTexture9);
                Graphics.Blit(renderTexture2, renderTexture3);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);
            }
            else if (pictureCount == 3)
            {
                Graphics.Blit(renderTexture9, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture9);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);
            }
            else if (pictureCount == 2)
            {
                Graphics.Blit(renderTexture2, swapSlot);
                Graphics.Blit(renderTexture1, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture1);
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
            }
            else if (pictureCount == 5)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture4, renderTexture3);
                Graphics.Blit(renderTexture9, renderTexture4);
                Graphics.Blit(swapSlot, renderTexture9);
            }
            else if (pictureCount == 4)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture3, renderTexture2);
                Graphics.Blit(renderTexture9, renderTexture3);
                Graphics.Blit(swapSlot, renderTexture9);
            }
            else if (pictureCount == 3)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(renderTexture9, renderTexture2);
                Graphics.Blit(swapSlot, renderTexture9);
            }
            else if (pictureCount == 2)
            {
                Graphics.Blit(renderTexture1, swapSlot);
                Graphics.Blit(renderTexture2, renderTexture1);
                Graphics.Blit(swapSlot, renderTexture2);
            }

        }
    }
}
