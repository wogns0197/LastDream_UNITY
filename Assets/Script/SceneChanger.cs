﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
	public void ChangeSceneToGame(){		
		SceneManager.LoadScene("SampleScene");
		Time.timeScale=1;
	}
	public void ChangeSceneToStart(){
		// Debug.Log("player "+GameDirector.player_name_list[InitialGame.playernum]+  "'s coin = "+GameDirector.coin_get_num);		
		SceneManager.LoadScene("Start");
		Time.timeScale=1;
	}
	public void ChangeSceneToStage2(){
		// SceneManager.LoadScene("Stage2");
	}    
	public void ChangeSceneToStage3(){
		// SceneManager.LoadScene("Stage2");
	}    
    
}
