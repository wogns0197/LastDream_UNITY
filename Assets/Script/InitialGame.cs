using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitialGame : MonoBehaviour
{
    public static int playernum=-1;
    public Text playername;
    // public Text[] rank = [r1,r2,r3,r4,r5,r6,r7];

    void Start()
    {	
    	// for(int i=0;i<7;i++){
    	// 	rank[0]= 
    	// }
        for(int i=0;i<GameDirector.player_name_list.Count; i++){        	
        	GameObject.Find("r" + (i+1).ToString()).GetComponent<Text>().text = (i+1).ToString()+". "+ GameDirector.player_name_list[i]+  " = "+GameDirector.player_score_list[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
        	for(int i=0;i<GameDirector.player_name_list.Count;i++){
        		Debug.Log(GameDirector.player_name_list[i] +" : "+ GameDirector.player_score_list[i]);	
        	}
        	
        }
    }

    public void StartGame(){
    	GameDirector.player_name_list.Add(playername.GetComponent<Text>().text);
    	Time.timeScale = 1;   
    	SceneManager.LoadScene("SampleScene");
    	playernum++;
    }
}
