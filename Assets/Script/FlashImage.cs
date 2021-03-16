using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    // Start is called before the first frame update
    Image image = null;
    Coroutine _currentFlashRoutine = null;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartFlash(float secondsFlash, float maxAlpha, Color newColor) //플래시 시간 , 선명도 , 색
    {
        image.color = newColor;

        maxAlpha = Mathf.Clamp(maxAlpha, 0, 255);

        if (_currentFlashRoutine != null)
            StopCoroutine(_currentFlashRoutine);

            _currentFlashRoutine = StartCoroutine(Flash(secondsFlash, maxAlpha));
           
        
    }

    IEnumerator Flash(float secondsFlash, float maxAlpha)
    {
        //플래시 색이 들어올때
        float flashInDuration = secondsFlash / 2; //플래시를 누르면 플래시 시간 동안 색이 생기고(절반) 사라지고(절반) 하기 때문에
        for (float time = 0; time <= flashInDuration; time +=Time.deltaTime)
        {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, time / flashInDuration); // 현재 프레임에 선명도 정하기
            image.color = colorThisFrame;
            yield return null;
        }

        //플래시 색이 나갈때
        float flashOutDuration = secondsFlash / 2;
        for (float time = 0; time <= flashInDuration; time += Time.deltaTime)
        {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, time / flashOutDuration); //39번째줄과 다른 이유는 선명도 max에서 시작해서
            image.color = colorThisFrame;
            yield return null;

        }
    }

}
