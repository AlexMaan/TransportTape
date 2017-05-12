using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonQuit : MonoBehaviour {

	public void QuitToMenu() {
        SceneManager.LoadScene("Setup");
    }
}
