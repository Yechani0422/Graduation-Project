using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public Texture2D cursor;
    public Texture2D leftCursorClicked;
    public Vector2 MouseHotSpot = Vector2.zero;
    [SerializeField]
    public Vector2 leftClickedHotSpot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursor, MouseHotSpot, CursorMode.Auto);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(leftCursorClicked, leftClickedHotSpot, CursorMode.ForceSoftware);
        }
        if(Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursor, MouseHotSpot, CursorMode.Auto);
        }

    }

}
