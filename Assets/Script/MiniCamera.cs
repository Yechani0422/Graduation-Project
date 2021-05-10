using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = Camera.main.farClipPlane;

        //Vector3 dir = Camera.main.ScreenToWorldPoint(mousePos);
        //RaycastHit hit;
        //if(Physics.Raycast(transform.position,dir,out hit,mousePos.z))
        //{
        //    transform.position = hit.point;
        //}
        //if(Input.GetMouseButtonUp(0))
        //{
        //    Vector3 mouse_pos = Input.mousePosition;

        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.ScreenToWorldPoint(mouse_pos), Vector3.forward, out hit))
        //    {
        //        transform.position = hit.point;
        //        Debug.Log(hit.transform.name);
        //        //Destroy(hit.transform.gameObject);
        //    }
        //}
        //Debug.DrawRay(Input.mousePosition, Vector3.forward);

        CameraIndicator();
    }

    void CameraIndicator()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //Ability 2 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            
        }


        //Ability 2 Canvas Inputs
        var hitPosDir = (hit.point - transform.position).normalized;
        float distance = Vector3.Distance(hit.point, transform.position);
        distance = Mathf.Min(distance, 8.3f);
        var newHitPos = transform.position + hitPosDir * distance;
        transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z+1);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Want")
        {
            Debug.Log("Want");
        }
    }
}
