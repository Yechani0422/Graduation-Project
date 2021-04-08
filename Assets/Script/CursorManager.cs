using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D leftCursorClicked;

    public Vector2 cursorHotSpot = Vector2.zero;
    [SerializeField]
    public Vector2 leftClickedHotSpot;

    Vector2 cursorPosition;
   

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, cursorHotSpot, CursorMode.Auto);
       
    }

    private void Update()
    {

       
       
        if (Input.GetMouseButtonDown(0))
        {
            cursorPosition = Input.mousePosition;
            Cursor.SetCursor(leftCursorClicked, leftClickedHotSpot, CursorMode.ForceSoftware);
            StartCoroutine("Capture");
        }
        if(Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursor, cursorHotSpot, CursorMode.Auto);
        }

    }


    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();

        byte[] imgBytes;
        string filename = Application.productName + "_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        string location = @"F:\Wish\Graduation-Project\Assets\ScreenShot\";
        string finalLoc = location+filename;
       // string path = @"F:\Wish\Graduation-Project\Assets\ScreenShot\test.png";
        Texture2D screenShot = new Texture2D(leftCursorClicked.width, leftCursorClicked.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(cursorPosition.x -170, cursorPosition.y -124, leftCursorClicked.width , leftCursorClicked.height ), 0, 0, false);
        screenShot.Apply();
        imgBytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(finalLoc, imgBytes);
        Debug.Log(" has been saved");
    }
  
};