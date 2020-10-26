using UnityEngine;
using System.Collections;

public class BGM_STILLALIVE : MonoBehaviour {

	void Start () {

		DontDestroyOnLoad(transform.gameObject);

	}


}