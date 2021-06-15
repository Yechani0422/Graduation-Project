using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private int _StageID;
    private int _Stage1Score;
    private int _Stage2Score;
    private int _Stage3Score;
    private int _Stage4Score;

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

    public int Stage1Score
    {
        get { return _Stage1Score; }
        set { _Stage1Score = value; }
    }

    public int Stage2Score
    {
        get { return _Stage2Score; }
        set { _Stage2Score = value; }
    }

    public int Stage3Score
    {
        get { return _Stage3Score; }
        set { _Stage3Score = value; }
    }

    public int Stage4Score
    {
        get { return _Stage4Score; }
        set { _Stage4Score = value; }
    }
}
