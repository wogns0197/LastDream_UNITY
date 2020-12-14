using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour//clear씬에서 사용
{
	public void ChangeSceneToGame(){		
		SceneManager.LoadScene("SampleScene");
		Time.timeScale=1;
	}
	public void ChangeSceneToStart(){
		// Debug.Log("player "+GameDirector.player_name_list[InitialGame.playernum]+  "'s coin = "+GameDirector.coin_get_num);		
		Destroy(GameObject.Find("BGM"));		
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
