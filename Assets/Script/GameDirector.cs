using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public static int coin_get_num;
    bool clicked = false;
    public GameObject pausemenu, jumpbutton;
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
    }

}
