using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuddleMove : MonoBehaviour
{
    public float MoveSpeed;
    float[] huddlegenpos = {1,54f,109f,180f,217f,268f,364f};
    void Start()
    {
        MoveSpeed = GameObject.Find("HuddleGenerator").GetComponent<HuddleGenerator>().huddle_speed;
        

    }

    // Update is called once per frame

    
    void Update()
    {   
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
