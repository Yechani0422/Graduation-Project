using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField]
    private CursorManager cursorManager;
    public RenderTexture renderTexture1;
    public RenderTexture renderTexture2;

    [SerializeField]
    private Image Picture1;
    [SerializeField]
    private Image Picture2;


    private int pictureCount;
    // Start is called before the first frame update
    void Start()
    {
        pictureCount = 0;
        renderTexture1.Release();
        renderTexture2.Release();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if (pictureCount == 0)
            {
                Graphics.Blit(cursorManager.screenShot, renderTexture1);
                pictureCount += 1;
            }
            else if (pictureCount == 1)
            {
                Graphics.Blit(cursorManager.screenShot, renderTexture2);
                pictureCount += 1;
            }
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
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 swapPos = Picture1.transform.position;
            Vector3 swapScale = Picture1.transform.localScale;
            Picture1.transform.position = Picture2.transform.position;
            Picture1.transform.localScale = Picture2.transform.localScale;
            Picture2.transform.position = swapPos;
            Picture2.transform.localScale = swapScale;
            renderTexture1.depth = 1;
            renderTexture2.depth =-1;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 swapPos = Picture1.transform.position;
            Vector3 swapScale = Picture1.transform.localScale;
            Picture1.transform.position = Picture2.transform.position;
            Picture1.transform.localScale = Picture2.transform.localScale;
            Picture2.transform.position = swapPos;
            Picture2.transform.localScale = swapScale;
        }
    }
}
