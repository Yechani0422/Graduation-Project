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
    BoxCollider2D boxCollider2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2d = GetComponent<BoxCollider2D>();
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
      if (isJump==true&&Input.GetKeyDown(KeyCode.Space))
       {
            
             rigidbody.AddForce(new Vector2(0, maxJump), ForceMode2D.Impulse);
             isJump = false;
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

    ////점프가능여부
    //private bool IsGrounded()
    //{
    //    float extraHeightText = 0.1f;
    //    RaycastHit2D rayhit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0, Vector2.down, extraHeightText, LayerMask.GetMask("Ground"));
    //    Color rayColor;

    //    if(rayhit.collider!=null)
    //    {
    //        rayColor = Color.green;
    //    }
    //    else
    //    {
    //        rayColor = Color.red;
    //    }

    //    Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
    //    Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
    //    Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, boxCollider2d.bounds.extents.y + extraHeightText), Vector2.right *( boxCollider2d.bounds.extents.x * 2f), rayColor);

    //    return rayhit.collider != null;
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FLOOR")
        {
            if(rigidbody.velocity.y<=0)
            {
                isJump = true;
                Debug.Log("JumpTrue");
            }           
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "FLOOR")
        {           
             isJump = false;
             Debug.Log("JumpFalse");
        }
    }
}
