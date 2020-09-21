using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuddleMove : MonoBehaviour
{
    public float MoveSpeed;
    void Start()
    {
        MoveSpeed = GameObject.Find("HuddleGenerator").GetComponent<HuddleGenerator>().huddle_speed;

    }

    // Update is called once per frame
    void Update()
    {   
        if(Time.timeScale!=0){
            this.transform.Translate(Vector2.left * MoveSpeed);        
            if(this.transform.position.x < 0){
                Destroy(gameObject);
            }
        }
        
    }
}
