using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPage : MonoBehaviour
{
    public GameObject Startpage, Ranking;   
    void Start()
    {
        Startpage.SetActive(false);
        Ranking.transform.localPosition = new Vector3(0, 0, 501f); //메인 페이지에 랭킹리스트 안뜨게 하는 방법
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
        	this.gameObject.SetActive(false);
        	Startpage.SetActive(true);
            Ranking.transform.localPosition = new Vector3(0, 0, 1f); // 다시 뜨게
        }
    }
}
