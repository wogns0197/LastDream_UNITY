using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour
{
    public GameObject Startpage, Ranking;   
    // float time,scales;
    // int switchcase;
    void Start()
    {   
        // scales = 0.008f;
        // time = 0;
        // switchcase = 1;
        Startpage.SetActive(false);
        Ranking.transform.localPosition = new Vector3(0, 0, 501f); //메인 페이지에 랭킹리스트 안뜨게 하는 방법
    }

    // Update is called once per frame
    void Update()
    {
        // time += Time.deltaTime;
        // if(time > 0.05f){
        //     time = 0;
        //     switch(switchcase){
        //         case 1:
        //             this.transform.position += new Vector3(scales, 0, 0);
        //             switchcase = 2;
        //             break;
        //         case 2:
        //             this.transform.position += new Vector3(-scales, 0, 0);
        //             switchcase = 3;
        //             break;
        //         case 3:
        //             this.transform.position += new Vector3(-scales, 0, 0);
        //             switchcase = 4;
        //             break;
        //         case 4:
        //             this.transform.position += new Vector3(scales, 0, 0);
        //             switchcase = 1;
        //             break;
        //     }
        // }

        if(Input.GetMouseButtonDown(0)){
        	this.gameObject.SetActive(false);
        	Startpage.SetActive(true);
            Ranking.transform.localPosition = new Vector3(0, 0, 1f); // 다시 뜨게
        }
    }
}
