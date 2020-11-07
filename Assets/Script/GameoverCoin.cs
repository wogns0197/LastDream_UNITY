using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverCoin : MonoBehaviour
{
    // public int gameovercoinnum;
    public Text text_coin;
    public static float dead_pos;
    public GameObject bar;
    void Start()
    {        
        
        text_coin.GetComponent<Text>().text = ""+GameDirector.coin_get_num;
        bar.transform.position = new Vector3(bar.transform.position.x + (dead_pos/356)*7.33f, -1.38f, 2);
        // Debug.Log((dead_pos/222)*10.4f);
        // bar.transform.position = Vector2.Lerp(bar.transform.position, new Vector3(bar.transform.position.x + (dead_pos/222)*10.4f, -1.1f, 2), 0.05f);
    }
    void Update()
    {
        
    }
}
