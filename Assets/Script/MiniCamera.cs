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
    private Image baseeffect;
    [SerializeField]
    private Image phantomeffect;
    [SerializeField]
    private GameObject player;

    private bool isPressed;

   
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        rawImage.enabled = false;
        image.enabled = false;
        baseeffect.enabled = false;
        phantomeffect.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        Manager manager = FindObjectOfType<Manager>();
        InventoryManager inventory = FindObjectOfType<InventoryManager>();
        
        if (manager.isPause == false)
        {

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
               inventory.modeChange = true;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                inventory.modeChange = false;
            }

            if (Input.GetMouseButton(0))
            {
                if (inventory.showInventory == false)
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
            }

         

            if (Input.GetMouseButtonUp(0))
            {
                if (inventory.showInventory == false)
                {
                    if(inventory.modeChange == false)
                    {
                        isPressed = false;
                        rawImage.enabled = false;
                        image.enabled = false;
                        StartCoroutine("BaseEffect");
                    }
                    else if(inventory.modeChange == true)
                    {
                        isPressed = false;
                        rawImage.enabled = false;
                        image.enabled = false;
                        StartCoroutine("PhantomEffect");
                    }


                     
                
                    
                }
            }

          


        }

    }
    IEnumerator BaseEffect()
    {
        SoundManager.instance.SFXPlay("FlashSound", clip);
        baseeffect.enabled = true;
        yield return new WaitForSeconds(0.05f);
        baseeffect.enabled = false;
    }

    IEnumerator PhantomEffect()
    {
        SoundManager.instance.SFXPlay("FlashSound", clip);
        phantomeffect.enabled = true;
        yield return new WaitForSeconds(0.05f);
        phantomeffect.enabled = false;
    }
}
