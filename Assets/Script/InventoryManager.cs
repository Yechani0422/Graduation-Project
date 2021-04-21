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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            screenShot = new Texture2D(pictureWidth, pictureHeight, TextureFormat.RGB24, false);
            screenShot.ReadPixels(new Rect(Input.mousePosition.x+10-pictureWidth/2,Input.mousePosition.y-10-pictureHeight/2, pictureWidth, pictureHeight), 0, 0, false);
            screenShot.Apply();

            enqueue(screenShot);
        }

        


        if (Input.GetMouseButtonDown(1))
        {
            if (pictureCount == 1)
            {
                renderTexture1.Release();
                pictureCount -= 1;
            }
            else if (pictureCount == 2)
            {
                renderTexture2.Release();
                pictureCount -= 1;
            }
            else if (pictureCount == 3)
            {
                renderTexture3.Release();
                pictureCount -= 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            //Vector3 swapPos = Picture1.transform.position;
            //Vector3 swapScale = Picture1.transform.localScale;
            //Picture1.transform.position = Picture2.transform.position;
            //Picture1.transform.localScale = Picture2.transform.localScale;
            //Picture2.transform.position = swapPos;
            //Picture2.transform.localScale = swapScale;

            RenderTexture swatR;

            Graphics.Blit(renderTexture1, renderTexture2);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Vector3 swapPos = Picture1.transform.position;
            //Vector3 swapScale = Picture1.transform.localScale;
            //Picture1.transform.position = Picture2.transform.position;
            //Picture1.transform.localScale = Picture2.transform.localScale;
            //Picture2.transform.position = swapPos;
            //Picture2.transform.localScale = swapScale;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            canvas1.sortingOrder = 2;
            canvas2.sortingOrder = 1;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            canvas1.sortingOrder = 1;
            canvas2.sortingOrder = 2;
        }
    }

    public void enqueue(Texture2D screenShot)
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
            Graphics.Blit(renderTexture2, renderTexture3);
            Graphics.Blit(renderTexture1, renderTexture2);
            Graphics.Blit(screenShot, renderTexture1);
            pictureCount += 1;
        }
    }
}
