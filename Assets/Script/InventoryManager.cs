using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField]
    public RenderTexture renderTexture1;
    public RenderTexture renderTexture2;
    public RenderTexture renderTexture3;
    public RenderTexture renderTexture4;
    public RenderTexture renderTexture5;
    public RenderTexture renderTexture6;
    public RenderTexture renderTexture7;
    public RenderTexture renderTexture8;
    public RenderTexture renderTexture9;

    public RenderTexture swapSlot;

    [SerializeField]
    private Canvas canvas1;
    [SerializeField]
    private Canvas canvas2;
    [SerializeField]
    private Canvas canvas3;
    [SerializeField]
    private Canvas canvas4;
    [SerializeField]
    private Canvas canvas5;
    [SerializeField]
    private Canvas canvas6;
    [SerializeField]
    private Canvas canvas7;
    [SerializeField]
    private Canvas canvas8;
    [SerializeField]
    private Canvas canvas9;

    [SerializeField]
    private int pictureWidth;
    [SerializeField]
    private int pictureHeight;

    private int pictureCount;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            screenShot = new Texture2D(pictureWidth, pictureHeight, TextureFormat.RGB24, false);
            screenShot.ReadPixels(new Rect(Input.mousePosition.x+10-pictureWidth/2,Input.mousePosition.y-10-pictureHeight/2, pictureWidth, pictureHeight), 0, 0, false);
            screenShot.Apply();

            TakePicture(screenShot);
        }

        


        

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(pictureCount==9)
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
            if(pictureCount==9)
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

        DeletePicture();
    }

    public void TakePicture(Texture2D screenShot)
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

    public void DeletePicture()
    {
        if (Input.GetMouseButtonDown(1))
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
}
