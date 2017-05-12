using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetupStart : MonoBehaviour {

    public SetupSettings settings;

    public void StartPlayLevel() {
        settings.SaveSettings();
        SceneManager.LoadScene("Play2");
    }    
}
