using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    public SpriteRenderer SpringRend;
    public SpriteRenderer SummerRend;
    public SpriteRenderer FallRend;
    public SpriteRenderer WinterRend;

    private bool IsCollid=false;
    // Start is called before the first frame update
    void Start()
    {
        SpringRend.sortingOrder = -1;
        SummerRend.sortingOrder = -2;
        FallRend.sortingOrder = -2;
        WinterRend.sortingOrder = -2;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsCollid==true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (SpringRend.sortingOrder == -1)
                {
                    SpringRend.sortingOrder = -2;
                    SummerRend.sortingOrder = -1;
                }
                else if (SummerRend.sortingOrder == -1)
                {
                    SummerRend.sortingOrder = -2;
                    FallRend.sortingOrder = -1;
                }
                else if (FallRend.sortingOrder == -1)
                {
                    FallRend.sortingOrder = -2;
                    WinterRend.sortingOrder = -1;
                }
                else if (WinterRend.sortingOrder == -1)
                {
                    WinterRend.sortingOrder = -2;
                    SpringRend.sortingOrder = -1;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (SpringRend.sortingOrder == -1)
                {
                    SpringRend.sortingOrder = -2;
                    WinterRend.sortingOrder = -1;
                }
                else if (WinterRend.sortingOrder == -1)
                {
                    WinterRend.sortingOrder = -2;
                    FallRend.sortingOrder = -1;
                }
                else if (FallRend.sortingOrder == -1)
                {
                    FallRend.sortingOrder = -2;
                    SummerRend.sortingOrder = -1;
                }
                else if (SummerRend.sortingOrder == -1)
                {
                    SummerRend.sortingOrder = -2;
                    SpringRend.sortingOrder = -1;
                }
            }
        }       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        IsCollid = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsCollid = false;
    }
}
