using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour
{
    [SerializeField] FlashImage isFlashImage = null;
    [SerializeField] Color isColor = Color.white;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            isFlashImage.StartFlash(0.5f, 1.0f, isColor);
            Debug.Log("flash");
        }
    }
}
