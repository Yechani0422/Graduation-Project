using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMove : MonoBehaviour
{
    [SerializeField]
    public float speed;

    private Transform target;
    private bool isFlip;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        isFlip = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().isFlip;
        if (isFlip==true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(1.0f, 1.0f, 0.0f), speed * Time.deltaTime);
        }
        else if (isFlip == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(-1.0f, 1.0f, 0.0f), speed * Time.deltaTime);
        }
    }
}
