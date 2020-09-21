using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
	public void ChangeSceneToGame(){		
		SceneManager.LoadScene("SampleScene");
		Time.timeScale=1;
	}
	public void ChangeSceneToStage2(){
		// SceneManager.LoadScene("Stage2");
	}    
	public void ChangeSceneToStage3(){
		// SceneManager.LoadScene("Stage2");
	}    
    
}
