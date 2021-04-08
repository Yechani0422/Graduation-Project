using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private int _StageID;
    private void Awake()
    {        
        var dontDestroy = FindObjectsOfType<DontDestroyOnLoad>();

        if(dontDestroy.Length==1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int StageID
    {
        get { return _StageID; }
        set { _StageID = value; }
    }
}
