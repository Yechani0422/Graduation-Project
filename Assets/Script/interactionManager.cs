using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionManager : MonoBehaviour
{
    [HideInInspector]
    public string interactionName;

    private bool modeChange;

    // Start is called before the first frame update
    void Start()
    {
        modeChange = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            modeChange = false;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            modeChange = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Want")
        {
            interactionName= other.gameObject.name;
        }

        if(modeChange == true)
        {
            if (other.gameObject.tag == "Phantom")
            {
                interactionName = other.gameObject.name;
                PhantomObj phantomObj = FindObjectOfType<PhantomObj>();
                if (Input.GetMouseButtonUp(0))
                {
                    phantomObj.visible = true;
                }

            }
        }
     
    }

    void OnTriggerExit(Collider other)
    {
        interactionName = "null";
    }

}
