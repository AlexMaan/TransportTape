using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    int roundTime;
    Text text;

	void Start (){
        roundTime = FindObjectOfType<TapeManager>().roundTime;
        text = GetComponent<Text>();
        text.text = roundTime.ToString();
        InvokeRepeating("SecondsCount", 0, 1);
	}
	
	void SecondsCount(){
        if (roundTime > 0) roundTime--;
        //else EndRound();
        text.text = roundTime.ToString();
    }

    void EndRound(){
        SceneManager.LoadScene("End");
    }
}
