using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public Text LoadButton;
    public string time="----";
    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        LoadButton.text = time;
    }

    public void OnClickSave()
    {
        PlayerPrefs.SetString("Time", System.DateTime.Now.ToString());
        time = System.DateTime.Now.ToString();
    }

    public void Load()
    {
        time=PlayerPrefs.GetString("Time");
    }
}
