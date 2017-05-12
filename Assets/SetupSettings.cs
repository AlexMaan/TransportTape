using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupSettings : MonoBehaviour {

    public static SetupSettings settings;

    public float defStartSpeed;
    public float defSpeedProgress;
    [Space(10)]
    public InputField InputStartSpeed;
    public InputField InputSpeedProgress;


    void Awake() {
        //if (settings == null) settings = this;
        //else Destroy(gameObject);
        //DontDestroyOnLoad(gameObject);
        //PlayerPrefs.DeleteAll();   
        LoadSettings();
    }

    public void SaveSettings() {
        PlayerPrefs.SetString("setupStartSpeed", InputStartSpeed.text);
        PlayerPrefs.SetString("setupSpeedProgress", InputSpeedProgress.text);
    }

    public void LoadSettings() {
        ResetSettings();  
        if (PlayerPrefs.HasKey("setupStartSpeed")) InputStartSpeed.text = PlayerPrefs.GetString("setupStartSpeed");
        if (PlayerPrefs.HasKey("setupSpeedProgress")) InputSpeedProgress.text = PlayerPrefs.GetString("setupSpeedProgress");
    }

    public void ResetSettings() {
        ResetSpeed();
        ResetRows();
        ResetShapes();
    }

    public void ResetSpeed() {
        InputStartSpeed.text = defStartSpeed.ToString();
        InputSpeedProgress.text = defSpeedProgress.ToString();
    }
    public void ResetRows() {

    }
    public void ResetShapes() {

    }
}
