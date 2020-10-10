using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour
{
    public float maxspeed,jumpPower,time;
    public GameObject topbar,topdiamond,huddle;
    public int life; // 게임디렉터에 넣기에 애매함.    
    bool supermode;
    private int jumpnum;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Start(){
    	maxspeed = 18f;
    	jumpPower = 60f;
        life = 3;
        time = 0;
        jumpnum = 0;
        supermode = false;
        huddle.GetComponent<BoxCollider2D>().enabled=true;        
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator> ();
        topbar = GameObject.Find("top_bar");
        topdiamond =GameObject.Find("top_diamond");
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if(supermode){ // life 하나 사라졌을 때 2초동안 무적 유지
            if(time >2f){ // 무적 끝
                if(GameObject.FindGameObjectWithTag("huddle") != null){GameObject.FindGameObjectWithTag("huddle").GetComponent<BoxCollider2D>().isTrigger= false;}
                supermode=false;
                time = 0;
                this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            }
            else{
                if(GameObject.FindGameObjectWithTag("huddle")!=null){GameObject.FindGameObjectWithTag("huddle").GetComponent<BoxCollider2D>().isTrigger= true;}
            }   
        }
        //Jump
        
        if (Input.GetButtonDown("Jump")){
            if(this.transform.position.y > -3f){//밑으로 떨어질 시 점프 불가 지면위에 있을때 y = -1.984775
                if(jumpnum <2){
                    if(jumpnum==0){
                        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                        anim.SetBool("is jumping", true);    
                        jumpnum++;    
                    }
                    else{
                        rigid.AddForce(Vector2.up * jumpPower *0.9f, ForceMode2D.Impulse);
                        anim.SetBool("is jumping", true);    
                        jumpnum++;
                    }
                }
                
                

                // 떨어질 때쯤 점프 한번 더 할 수 있는 코드
                // if(! isJumping){ 
                //     isJumping = true;
                //     rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                //     anim.SetBool("is jumping", true);    
                // }
                // else{
                //     if( rigid.velocity.y<-5f && downingflag==1){
                //         anim.SetBool("is jumping", false);       
                //         rigid.AddForce(Vector2.up * jumpPower*1.4f, ForceMode2D.Impulse);
                //         anim.SetBool("is jumping", true);       
                //         downingflag++;
                //     }
                // }
            }            
        }

        //추가한코드 --> 속력말고 좌표로 나중에 수정하기
        if (Mathf.Abs(rigid.velocity.y) == 0){        
            anim.SetBool("is jumping", false);
            jumpnum=0;
        }
        // if( < 0){
        //     isDowning=true;
        // }

            //Stop Speed
            if (Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f, rigid.velocity.y);
        }

        //Direction Sprite
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Animation
        if ( Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("is walking", false);
        else
            anim.SetBool("is walking", true);

        //밑으로 떨어지면 gameover!
        if(this.transform.position.y < -5f){
            // SceneManager.LoadScene("GameOver");
            GotoBack(this.transform.position);
            lifeminus(life--);
        }
        // -23 ~ -3.9 == 19.1
        //     /356 =  0.053651685393258
        // "로컬포지션" 수정시 조심!
        if(this.transform.position.x>0){            
            topbar.transform.localPosition = new Vector3( -23f +gameObject.transform.localPosition.x*0.053651685393258f, 4.9f, 2);
        }
        if(this.transform.position.x>357f){
            SceneManager.LoadScene("Clear");
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            lifeminus(life--);
        }

    }

    void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
       
        //Max Speed
        if (rigid.velocity.x > maxspeed) //Right Max Speed
            rigid.velocity = new Vector2(maxspeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxspeed*(-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxspeed*(-1), rigid.velocity.y);

        //Landing Platform
        Debug.DrawRay(rigid.position, Vector3.down*2, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if(rayHit.collider != null) {
            if (rayHit.distance < 0.5f)
            Debug.Log(rayHit.collider.name);
        }
    }

    
    //안전한 포인트를 정해야할 것 같음
    void GotoBack(Vector3 pos){
        this.transform.position = new Vector3( pos.x-5f, 1.5f, pos.z);
        // if(col_huddle!=null){col_huddle.GetComponent<BoxCollider2D>().enabled=false;}
        supermode = true;
        time = 0;
        this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);                
    }   
    void lifeminus(int num){
        if(num==3){GameObject.Find("top_hart3").SetActive(false);}
        else if(num==2){GameObject.Find("top_hart2").SetActive(false);}
        else if(num==1){GameObject.Find("top_hart").SetActive(false);}
        else if(num==0){
            SceneManager.LoadScene("GameOver");
           GameoverCoin.dead_pos = this.transform.position.x+5f;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other){        
        if(other.gameObject.tag == "huddle"){
            Destroy(other.gameObject);
            GotoBack(this.transform.position);
            lifeminus(life--);                    
            // GotoBack(this.transform.position);
        }
    }


    public void jump(){
        //점프 버튼용 함수
        if(this.transform.position.y > -2f){//밑으로 떨어질 시 점프 불가 지면위에 있을때 y = -1.984775            
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("is jumping", true);    
            
            
        }  
    }


}
