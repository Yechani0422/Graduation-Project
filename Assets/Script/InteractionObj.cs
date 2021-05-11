using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObj : MonoBehaviour
{
    [SerializeField]
    private GameObject Bubble;
    [SerializeField]
    private GameObject Want;
    [SerializeField]
    public string wantName;
    [HideInInspector]
    public bool isInteraction;

    [SerializeField]
    private InventoryManager inventoryManager;
    
    void Start()
    {
        isInteraction = false;
        Bubble.SetActive(false);
        Want.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(inventoryManager.isDead==true)
        {
            inventoryManager.isDead = false;
            Destroy(gameObject);
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteraction = true;
            Bubble.SetActive(true);
            Want.SetActive(true);    
            Debug.Log("enter");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteraction = false;
            Bubble.SetActive(false);
            Want.SetActive(false);
            Debug.Log("exit");
        }
    }
}
