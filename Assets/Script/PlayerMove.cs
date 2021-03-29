using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed; //최고속도

    [SerializeField]
    public float maxJump;  //점프높이

    private bool isWalk = false;

    private bool isJump = false;

    public bool isFlip = false;//펫 이 쫒아갈 좌표설정때문에

    public enum PlayerState { idle, walk, jump };

    public PlayerState playerState = PlayerState.idle;

    Animator anim;

    

    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider2d;
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * maxSpeed * Time.deltaTime);
            isWalk = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
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
      if (isJump==false&&Input.GetKeyDown(KeyCode.Space))
       {
            isJump = true;
            rigidbody.AddForce(new Vector2(0, maxJump), ForceMode2D.Impulse);            
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
                isJump = false;
                Debug.Log("jumpfalse");
            }           
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "FLOOR")
        {
            if (rigidbody.velocity.y > 0)
            {
                isJump = true;
                Debug.Log("jumptrue");
            }                
        }
    }


    IEnumerator IsPlayerState()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.0000001f);


            if (isWalk == true && isJump == false)
            {
                playerState = PlayerState.walk;
            }
            else if(isJump==true)
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
                    anim.SetBool("IsJump", false);
                    break;
                case PlayerState.walk:
                    anim.SetBool("IsWalk", true);
                    anim.SetBool("IsJump", false);
                    break;
                case PlayerState.jump:
                    anim.SetBool("IsJump", true);
                    anim.SetBool("IsWalk", false);
                    break;
            }
            yield return null;
        }
      
    }
}
