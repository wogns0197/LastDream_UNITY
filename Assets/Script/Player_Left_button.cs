using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Left_button : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public GameObject player;
    float maxspeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    bool isDown;
    int side;
    void Start()
    {	
    	isDown = false;
        maxspeed = 6f;
        rigid = player.GetComponent<Rigidbody2D>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    	if(isDown){
    		spriteRenderer.flipX = side == 1;
	        rigid.AddForce(Vector2.left * side, ForceMode2D.Impulse);       
	        //Max Speed
	        if (rigid.velocity.x > maxspeed) //Right Max Speed
	            rigid.velocity = new Vector2(maxspeed, rigid.velocity.y);
	        else if (rigid.velocity.x < maxspeed*(-1)) //Left Max Speed
	            rigid.velocity = new Vector2(maxspeed*(-1), rigid.velocity.y);
	        //Direction Sprite
	        if (Input.GetButtonDown("Horizontal"))
	            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;	
	        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
    	}
    	
    		
    	
        
    }
    public void OnPointerDown(PointerEventData eventData){
        if(this.name == "button_Right" ){
        	side = -1;
        }
        else{
        	side = 1;
        }
        isDown = true;
    }
    public void OnPointerUp(PointerEventData eventData){
        // if(this.name == "button_Right" ){
    	rigid.velocity = new Vector2(rigid.velocity.normalized.x*0.5f, rigid.velocity.y);
        // }
        isDown = false;
    }
}
