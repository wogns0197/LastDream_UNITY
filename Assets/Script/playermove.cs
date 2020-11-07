using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Events;

public class playermove : MonoBehaviour 
{
    public float maxspeed,jumpPower,time;
    public GameObject topbar,topdiamond,huddle,moon, coin_easter_only, col_coin_audio;
    public int life; // 게임디렉터에 넣기에 애매함.    
    public AudioClip[] soundlist;
    AudioSource soundsource;
    bool supermode;
    private int jumpnum,easter_i;
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
        easter_i = 1;
        huddle.GetComponent<BoxCollider2D>().enabled=true;        
        soundsource = this.GetComponent<AudioSource>();
        soundsource.volume = 0.5f;
    }

    void Awake()
    {
        Application.targetFrameRate = 60;
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
                // if(GameObject.FindGameObjectWithTag("huddle") != null){GameObject.FindGameObjectWithTag("huddle").GetComponent<BoxCollider2D>().isTrigger= false;}
                supermode=false;
                time = 0;
                this.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
            }
            // else{                
            //     if(GameObject.FindGameObjectWithTag("huddle")!=null){GameObject.FindGameObjectWithTag("huddle").GetComponent<BoxCollider2D>().isTrigger= true;}
            // }   
        }
        //Jump
        
        if (Input.GetButtonDown("Jump")){
            if(this.transform.position.y > -3f){//밑으로 떨어질 시 점프 불가 지면위에 있을때 y = -1.984775
                soundsource.clip = soundlist[0];
                soundsource.volume = 0.3f;
                soundsource.loop = false;
                soundsource.Play();
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
            if(jumpnum!=0){
                soundsource.clip = soundlist[1];
                soundsource.loop = false;
                soundsource.volume = 0.28f;
                soundsource.Play();
            }
            anim.SetBool("is jumping", false);            
            jumpnum=0;            
            if(! soundsource.isPlaying && Mathf.Abs(rigid.velocity.x) > 1f ) {
                soundsource.clip = soundlist[2];
                soundsource.volume = 0.1f;
                soundsource.loop = false;
                soundsource.Play();    
            }
            
        }
            //Stop Speed
            if (Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f, rigid.velocity.y);
        }

        

        //Animation
        if ( Mathf.Abs(rigid.velocity.x) < 0.5)
            anim.SetBool("is walking", false);
        else{
            anim.SetBool("is walking", true);            
        }

        //밑으로 떨어지면 gameover!
        if(this.transform.position.y < -5f){
            // SceneManager.LoadScene("GameOver");
            GotoBack(this.transform.position);
            lifeminus(life--);
        }
        // -23 ~ -3.9 == 19.1
        //     /356 =  0.053651685393258
        // "로컬포지션" 수정시 조심!

        // -19.7 ~ -6.99 / 356 = 0.035702247191011
        if(this.transform.position.x>0){            
            topbar.transform.localPosition = new Vector3( -19.7f +gameObject.transform.localPosition.x*0.035702247191011f, 4.9f, 2);
        }

        if(this.transform.position.x>357f){ // clear!
            InitialGame.playerlist[InitialGame.playernum].score = GameDirector.coin_get_num;
            GameDirector.rank_list.Add(InitialGame.playerlist[InitialGame.playernum]); 
            SceneManager.LoadScene("Clear");
        }

        if(Input.GetKeyDown(KeyCode.Q)){ //testbutton
            lifeminus(life--);
        }
        if(Input.GetKeyDown(KeyCode.W)){ //testbutton
            GameDirector.coin_get_num++;
        }
        if(Input.GetKeyDown(KeyCode.E)){ //testbutton
            this.transform.position += new Vector3(350f, 0, 0);
        }
        
            
        

        //달 위치조정
        moon.transform.position = new Vector3(this.transform.position.x, 6.5f, 0);

        

    }//Update end

    
    // void FixedUpdate()
    // {        

        // Landing Platform
        // Debug.DrawRay(rigid.position, Vector3.down*2, new Color(0, 1, 0));

        // RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        // if(rayHit.collider != null) {
        //     if (rayHit.distance < 0.5f)
        //     Debug.Log(rayHit.collider.name);
        // }
    // }

    
    
    //안전한 포인트를 정해야할 것 같음
    void GotoBack(Vector3 pos){
        this.transform.position = new Vector3( pos.x-5f, 2f, pos.z);
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
            InitialGame.playerlist[InitialGame.playernum].score = GameDirector.coin_get_num;
            GameDirector.rank_list.Add(InitialGame.playerlist[InitialGame.playernum]);
            // GameDirector.player_score_list.Add(GameDirector.coin_get_num);
            SceneManager.LoadScene("GameOver");
           GameoverCoin.dead_pos = this.transform.position.x+5f;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other){
        if( other.gameObject.tag == "huddle"){            
            if( !supermode){
                Destroy(other.gameObject);
                GotoBack(this.transform.position);
                lifeminus(life--);                    
                // GotoBack(this.transform.position);
            }
        
            else{
                Destroy(other.gameObject);
            }
        }            
    }
    void OnTriggerEnter2D(Collider2D other){
        if( (other.gameObject.name == "box1" && easter_i == 1) || (other.gameObject.name == "box2" && easter_i == 2)){
            easter_i++;
            for(int i=0; i<10; i++){
                Instantiate(coin_easter_only, 
                    new Vector3(this.transform.position.x,this.transform.position.y+i/1.5f,this.transform.position.z),
                     Quaternion.identity);    
            }
            
        }
        if(other.gameObject.name == "box3" && easter_i == 3){
            this.transform.position = new Vector3(150f, 5f, this.transform.position.z);
        }

    }


    public void jump(){
        //점프 버튼용 함수
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

            }     
    }


}
