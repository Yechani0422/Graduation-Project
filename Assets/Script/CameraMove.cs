using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    [SerializeField]
    public Vector3 offset;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x>=minX&&player.position.x<=maxX)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
        }
        else
        {
            Vector3 vec = transform.position;
            transform.position = new Vector3(vec.x, 6.508056f, vec.z);
        }
       
    }
}
