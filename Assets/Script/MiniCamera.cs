using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniCamera : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImage;
    [SerializeField]
    private Image image;
    [SerializeField]
    private GameObject player;

    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        rawImage.enabled = false;
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            isPressed = true;
            if (isPressed == true)
            {
                Vector3 mouse_pos = Input.mousePosition;

                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(mouse_pos);
                Physics.Raycast(ray, out hit);

                

                rawImage.enabled = true;
                image.enabled = true;

                //mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
                //if (Vector2.Distance(new Vector2(rawImage.transform.position.x, rawImage.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y)) < 10.0f)
                //{
                //    Debug.Log(Vector2.Distance(new Vector2(mouse_pos.x, mouse_pos.y), new Vector2(player.transform.position.x, player.transform.position.y)));
                //    transform.position = hit.point;
                //}

                var hitPosDir = (hit.point - player.transform.position).normalized;
                float distance = Vector3.Distance(hit.point, player.transform.position);
                distance = Mathf.Min(distance, 6.0f);
                var newHitPos = player.transform.position + hitPosDir * distance;
                transform.position = (newHitPos);
            }            
        }

        if(Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            rawImage.enabled = false;
            image.enabled = false;
        }
       

    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Want")
        {
            Debug.Log("Want");
        }
    }
}
