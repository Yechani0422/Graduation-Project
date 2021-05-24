using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomObj : MonoBehaviour
{
    [HideInInspector]
    public bool visible;



    // Start is called before the first frame update
    void Start()
    {
        visible = false;

      
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer render = gameObject.GetComponent<MeshRenderer>();

        if (visible == false)
        {
            render.enabled = false;
        }
 
        if (visible == true)
        {

            render.enabled = true;
          
        }
      
     
    }



}
