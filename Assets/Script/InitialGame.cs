using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class Player: MonoBehaviour{
	public string id;
	public int score;
	// public Player(string _id, int _score){
	// 	this.id = _id;
	// 	this.score = _score ;
	// }
}


public class InitialGame : Player
{
	public static Player[] playerlist = new Player[10];
    public static int playernum=-1;
    public Text playername;
    // public Text[] rank = [r1,r2,r3,r4,r5,r6,r7];
	



    void Start()
    {	
    	// for(int i=0;i<7;i++){
    	// 	rank[0]= 
    	// }
    	List<Player> ranking = GameDirector.rank_list.OrderByDescending(x => x.score).ToList();
        for(int i=0;i<playernum+1; i++){        	
        	GameObject.Find("r" + (i+1).ToString()).GetComponent<Text>().text = (i+1).ToString()+"등 "+ ranking[i].id+  " = "+ranking[i].score.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
    	// playerlist[0].setData(playername.GetComponent<Text>().text,0);
    	if(playername.GetComponent<Text>().text!=""){
    		playerlist[playernum +1] = new Player();
	    	playerlist[playernum +1].id = playername.GetComponent<Text>().text;
	    	playerlist[playernum +1].score = 0;
	    	
	    	
	    	Time.timeScale = 1;   
	    	SceneManager.LoadScene("SampleScene");
	    	playernum++;	
    	}
    	else{
    		Debug.Log("Input Name!");
    	}
    }
}

