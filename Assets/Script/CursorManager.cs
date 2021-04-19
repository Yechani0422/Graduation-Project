﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CursorManager : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D leftCursorClicked;
    public Vector2 cursorHotSpot = Vector2.zero;
    [SerializeField]
    public Vector2 leftClickedHotSpot;
    Vector2 cursorPosition;
  



    Vector2 position;
    public Image cameraRange;
    public Image camera;
    public Canvas cameraCanvas;
    private Vector2 posUp;
    public float maxCameraRange;
    bool cameraOn = false;

    public AudioClip clip;


    [SerializeField] FlashImage isFlashImage = null;
    [SerializeField] Color isColor = Color.black;
  






    void Start()
    {
        Cursor.SetCursor(cursor, cursorHotSpot, CursorMode.Auto);
        cameraRange.GetComponent<Image>().enabled = false;
        camera.GetComponent<Image>().enabled = false;

          

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            cameraOn = true;
            
            cameraRange.GetComponent<Image>().enabled = true;
            camera.GetComponent<Image>().enabled = true;
            // Cursor.SetCursor(leftCursorClicked, leftClickedHotSpot, CursorMode.ForceSoftware);
            Cursor.visible = true;
            
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            cameraOn = false;
            cameraRange.GetComponent<Image>().enabled = false;
            camera.GetComponent<Image>().enabled = false;
          // Cursor.visible = true;
            Cursor.SetCursor(cursor, cursorHotSpot, CursorMode.Auto);
            StartCoroutine("Capture");
        }
        
        if (cameraOn == true)
        {
            CameraIndicator();
        }
        
    
        

    }
        

  
    void CameraIndicator()
    {

        cursorPosition = Input.mousePosition;
        //Debug.Log(cursorPosition);
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

   
        //Ability 2 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject != this.gameObject)
            {
                posUp = new Vector3(hit.point.x, 10f, hit.point.z);
                position = hit.point;
            }
        }


        //Ability 2 Canvas Inputs
        var hitPosDir = (hit.point - transform.position).normalized;
        float distance = Vector3.Distance(hit.point, transform.position);
        distance = Mathf.Min(distance, maxCameraRange);
        var newHitPos =  transform.position + hitPosDir * distance;
        cameraCanvas.transform.position = (newHitPos);
    }
    
    

    IEnumerator Capture()
    {
        if(cursorPosition.x-150 <=622)
        {
            cursorPosition.x = 773;
        }
        if(cursorPosition.x-150 >=1977)
        {
            cursorPosition.x = 1836;
        }
        if(cursorPosition.y-140 <= 25)
        {
            cursorPosition.y = 165;
        }
        if(cursorPosition.y -140 >= 1020)
        {
            cursorPosition.y = 1160;
        }
      
        yield return new WaitForEndOfFrame();
        byte[] imgBytes;
        string filename = "ScreenShot" + "_" + System.DateTime.Now.ToString("ddHHmmss") + ".png";
        string location = @"F:\Wish\Graduation-Project\Assets\ScreenShot\";
        string finalLoc = location+filename;
        isFlashImage.StartFlash(0.5f, 1.0f, isColor);
        SoundManager.instance.SFXPlay("FlashSound",clip);
        Texture2D screenShot = new Texture2D(leftCursorClicked.width, leftCursorClicked.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(cursorPosition.x -150, cursorPosition.y-140 , leftCursorClicked.width, leftCursorClicked.height), 0, 0, false);
        //Debug.Log(cursorPosition.x - 150);
        screenShot.Apply();
        imgBytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(finalLoc, imgBytes);
       
    }
  
    

};