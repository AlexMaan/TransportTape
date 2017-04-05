using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour {

	public void RestartPlayScene(){
        TapeManager.points = 0;
        SceneManager.LoadScene("Play");
    }
}
