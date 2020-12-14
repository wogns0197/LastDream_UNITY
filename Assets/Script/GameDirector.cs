using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static int coin_get_num;
    // public static List<string> player_name_list = new List<string>();  //랭킹 이름 표시 리스트
    // public static List<int> player_score_list = new List<int>();  //랭킹 점수 표시 리스트
    public static List<Player> rank_list = new List<Player>(); // 랭킹 이름과 점수를 셋으로하는 객체를 모아둔 리스트
    bool clicked = false;
    public GameObject pausemenu, jumpbutton, leftbutton, rightbutton;
    //전역변수 선언 --> GameDirector.coin_get_num 으로 다른 스크립트에서 사용하면됨
    
    public Text text_coin;
    // private으로 바꾸기 , public 은 확인용

    
    void Start()
    {
        coin_get_num=0;
        pausemenu.SetActive(false); //시작 시 메뉴 뜨지않게
     	
    }

    // Update is called once per frame
    void Update()
    {	
        text_coin.GetComponent<Text>().text = "" + coin_get_num;
    }


    public void Pause(){
        if(!clicked){
            Time.timeScale = 0;
            pausemenu.SetActive(true);
            jumpbutton.SetActive(false);    
            rightbutton.SetActive(false);
            leftbutton.SetActive(false);
            clicked = true;
        }
        else{
            clicked = false;
            Resume();
        }
        
    }
    public void Resume(){
        Time.timeScale = 1;   
        pausemenu.SetActive(false);
        jumpbutton.SetActive(true);
        rightbutton.SetActive(true);
        leftbutton.SetActive(true);
    }    

    public void ToStartScene(){
        InitialGame.playerlist[InitialGame.playernum].score = coin_get_num;
        rank_list.Add(InitialGame.playerlist[InitialGame.playernum]);
        // player_score_list.Add(coin_get_num);
        Destroy(GameObject.Find("BGM"));        
        SceneManager.LoadScene("Start");
    }

}
