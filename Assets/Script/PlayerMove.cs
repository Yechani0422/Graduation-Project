using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed; //최고속도

    
    [SerializeField]
    public float jumpForce;//점프값

    private bool isWalk = false;

    private bool isGrounded = false;

    private bool isJumping = false;

    public bool isFlip = false;//펫 이 쫒아갈 좌표설정때문에

    public enum PlayerState { idle, walk, jump };

    public PlayerState playerState = PlayerState.idle;

    Animator anim;    

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;

    private float jumpTimeCounter;
    public float jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        StartCoroutine(this.IsPlayerState());
        StartCoroutine(this.PlayerAction());
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
        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * maxSpeed * Time.deltaTime);
            isWalk = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * maxSpeed * Time.deltaTime);
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
    }

    //점프
    void Jump()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            isJumping = true;
            //rigidbody.AddForce(new Vector2(0, maxJump), ForceMode2D.Impulse);
            rigidbody.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;

        }

        if (isJumping==true&&Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0)
            {
                //rigidbody.AddForce(new Vector2(0, maxJump), ForceMode2D.Impulse);
                rigidbody.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
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
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FLOOR")
        {
            if(rigidbody.velocity.y<0.01f)
            {
                isGrounded = true;
                Debug.Log("jumpfalse");
            }           
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "FLOOR")
        {
            if (rigidbody.velocity.y < 0)
            {
                isGrounded = false;
                Debug.Log("jumptrue");
            }

           // isGrounded = false;
        }
    }


    IEnumerator IsPlayerState()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.0000001f);


            if (isWalk == true && isGrounded == true)
            {
                playerState = PlayerState.walk;
            }
            else if(isGrounded == false)
            {
                playerState = PlayerState.jump;
            }
            else
            {
                playerState = PlayerState.idle;
            }
        }
      
        
    }

    IEnumerator PlayerAction()
    {
        while(true)
        {
            switch (playerState)
            {
                case PlayerState.idle:
                    anim.SetBool("IsWalk", false);
                    anim.SetBool("IsGrounded", false);
                    break;
                case PlayerState.walk:
                    anim.SetBool("IsWalk", true);
                    anim.SetBool("IsGrounded", false);
                    break;
                case PlayerState.jump:
                    //anim.SetBool("IsWalk", false);
                    anim.SetBool("IsGrounded", true);                    
                    break;
            }
            yield return null;
        }
      
    }
}
