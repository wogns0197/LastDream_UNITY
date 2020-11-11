using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuddleMove : MonoBehaviour
{   
    public GameObject player, jump_huddle;
    public float MoveSpeed;
    float[] huddlegenpos = {1,54f,109f,180f,217f,268f,364f};
    void Start()
    {
        player = GameObject.Find("player");
        MoveSpeed = SelectMode.huddlespeed;
        jump_huddle.SetActive(false);

    }

    
    void Update()
    {   
        if(player.transform.position.y > 0.34f){            
            jump_huddle.SetActive(true);
            jump_huddle.transform.position = new Vector3(this.transform.localPosition.x - 0.7f,player.transform.position.y - 2.62f,this.transform.position.z);
        }
        else{
            jump_huddle.SetActive(false);   
        }

        if(Time.timeScale!=0){
            this.transform.Translate(Vector2.left * MoveSpeed);        
            if(this.transform.position.x >huddlegenpos[0] && this.transform.position.x< huddlegenpos[0]+0.5f){
                Destroy(gameObject);
            }
            if(this.transform.position.x >huddlegenpos[1] && this.transform.position.x< huddlegenpos[1]+0.5f){
                Destroy(gameObject);
            }
            if(this.transform.position.x >huddlegenpos[2] && this.transform.position.x< huddlegenpos[2]+0.5f){
                Destroy(gameObject);
            }
            if(this.transform.position.x >huddlegenpos[3] && this.transform.position.x< huddlegenpos[3]+0.5f){
                Destroy(gameObject);
            }
            if(this.transform.position.x >huddlegenpos[4] && this.transform.position.x< huddlegenpos[4]+0.5f){
                Destroy(gameObject);
            }
            if(this.transform.position.x >huddlegenpos[5] && this.transform.position.x< huddlegenpos[5]+0.5f){
                Destroy(gameObject);
            }
            if(this.transform.position.x >huddlegenpos[6] && this.transform.position.x< huddlegenpos[6]+0.5f){
                Destroy(gameObject);
            }
        }
        
    }
}
