using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(waiter());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
	}
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}
