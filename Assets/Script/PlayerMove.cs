using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed; //최고속도

    [SerializeField]
    public float maxJump;  //점프높이

    private bool isJump = false;

    public bool isFlip = false;//펫 이 쫒아갈 좌표설정때문에

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        SpriteFlip();       
       
    }

    //이동
    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * maxSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * maxSpeed * Time.deltaTime);

        }
    }

    //점프
    void Jump()
    {
      
       if (Input.GetButtonDown("Jump"))
       {
             if(isJump==true)
             {
                rigidbody.AddForce(new Vector2(0, maxJump), ForceMode2D.Impulse);
                isJump = false;
             }                
       }
    }

    //스프라이트 좌우 플립
    void SpriteFlip()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            spriteRenderer.flipX = true;
            isFlip = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            spriteRenderer.flipX = false;
            isFlip = false;
        }
    }

    //점프가능여부
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="FLOOR")
        {
            isJump = true;
            Debug.Log("true");
        }
    }
}
