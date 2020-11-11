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
    public string mode;	
}


public class InitialGame : Player
{
    public GameObject Select_Canvas,Startpage,Modepage,EASY,NORMAL,HARD;
	public static Player[] playerlist = new Player[10];
    public static int playernum=-1;
    public Text playername;    
    public Sprite easy_off,easy_on,normal_off,normal_on,hard_off,hard_on;
    // public Text[] rank = [r1,r2,r3,r4,r5,r6,r7];
	List<Player> rank_e = new List<Player>(); 
    List<Player> rank_n = new List<Player>(); 
    List<Player> rank_h = new List<Player>(); 



    void Start()
    {	 
        //EASY 기본으로 보여주기
    	List<Player> ranking = GameDirector.rank_list.OrderByDescending(x => x.score).ToList();
        for(int i=0;i<playernum+1;i++){
            if(ranking[i].mode == "EASY"){
                rank_e.Add(ranking[i]);
            }
            else if(ranking[i].mode == "NORMAL"){
                rank_n.Add(ranking[i]);   
            }
            else if(ranking[i].mode == "HARD"){
                rank_h.Add(ranking[i]);   
            }
        }
        for(int i=0;i<rank_e.Count;i++){
            EASY.transform.GetChild(0).transform.GetChild(i).GetComponent<Text>().text = (i+1).ToString()+"등 " + rank_e[i].id+  " = "+rank_e[i].score.ToString();
        }
    }

    void Update(){}

    public void rank_E(){
        ChangeSprite(0);
        EASY.transform.GetChild(0).gameObject.SetActive(true);
        NORMAL.transform.GetChild(0).gameObject.SetActive(false);
        HARD.transform.GetChild(0).gameObject.SetActive(false);
        for(int i=0;i<rank_e.Count;i++){ 
            EASY.transform.GetChild(0).transform.GetChild(i).GetComponent<Text>().text= (i+1).ToString()+"등 " + rank_e[i].id+  " = "+rank_e[i].score.ToString();
        }
        
        
    }
    public void rank_N(){
        ChangeSprite(1);   
        EASY.transform.GetChild(0).gameObject.SetActive(false);
        NORMAL.transform.GetChild(0).gameObject.SetActive(true);
        HARD.transform.GetChild(0).gameObject.SetActive(false);
        for(int i=0;i<rank_n.Count;i++){ 
            NORMAL.transform.GetChild(0).transform.GetChild(i).GetComponent<Text>().text= (i+1).ToString()+"등 " + rank_n[i].id+  " = "+rank_n[i].score.ToString();
        }
    }
    public void rank_H(){
        ChangeSprite(2);
        EASY.transform.GetChild(0).gameObject.SetActive(false);
        NORMAL.transform.GetChild(0).gameObject.SetActive(false);
        HARD.transform.GetChild(0).gameObject.SetActive(true);
        for(int i=0;i<rank_h.Count;i++){ 
            HARD.transform.GetChild(0).transform.GetChild(i).GetComponent<Text>().text= (i+1).ToString()+"등 " + rank_h[i].id+  " = "+rank_h[i].score.ToString();
        }
    }

    void ChangeSprite(int num){
        EASY.GetComponent<SpriteRenderer>().sprite = easy_off;
        NORMAL.GetComponent<SpriteRenderer>().sprite = normal_off;
        HARD.GetComponent<SpriteRenderer>().sprite = hard_off;
        if(num==0){EASY.GetComponent<SpriteRenderer>().sprite = easy_on;}
        else if(num==1){NORMAL.GetComponent<SpriteRenderer>().sprite = normal_on;}
        else{HARD.GetComponent<SpriteRenderer>().sprite = hard_on;}
    }

    public void selectMode(){
        if(playername.GetComponent<Text>().text!=""){
            playerlist[playernum +1] = new Player();
            playerlist[playernum +1].id = playername.GetComponent<Text>().text;
            playerlist[playernum +1].score = 0;
        }    
        Select_Canvas.SetActive(false);
        Startpage.SetActive(false);
        Modepage.SetActive(true);
    }

    public void StartGame(){	    	
    	Time.timeScale = 1;   
    	SceneManager.LoadScene("SampleScene");
    	playernum++;	
    }
}

