using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupSettings : MonoBehaviour {

    public static SetupSettings settings;

    public float defStartSpeed;
    public float defSpeedProgress;
    public int defNumberRow;
    public float defRowPosition;
    public int defProgress;
    public int defDamage;
    public int defShapes;
    [Space(10)]
    public InputField InputStartSpeed;
    public InputField InputSpeedProgress;
    public InputField InputNumberRow;
    public InputField InputRowPosition;
    public InputField InputProgress;
    public InputField InputDamage;
    public InputField InputShapes;


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
        PlayerPrefs.SetString("setupNumberRow", InputNumberRow.text);
        PlayerPrefs.SetString("setupRowPosition", InputRowPosition.text);
        PlayerPrefs.SetString("setupProgress", InputProgress.text);
        PlayerPrefs.SetString("setupDamage", InputDamage.text);
        PlayerPrefs.SetString("setupShapes", InputShapes.text);
    }

    public void LoadSettings() {
        ResetSettings();  
        if (PlayerPrefs.HasKey("setupStartSpeed")) InputStartSpeed.text = PlayerPrefs.GetString("setupStartSpeed");
        if (PlayerPrefs.HasKey("setupSpeedProgress")) InputSpeedProgress.text = PlayerPrefs.GetString("setupSpeedProgress");
        if (PlayerPrefs.HasKey("setupNumberRow")) InputNumberRow.text = PlayerPrefs.GetString("setupNumberRow");
        if (PlayerPrefs.HasKey("setupRowPosition")) InputRowPosition.text = PlayerPrefs.GetString("setupRowPosition");
        if (PlayerPrefs.HasKey("setupProgress")) InputProgress.text = PlayerPrefs.GetString("setupProgress");
        if (PlayerPrefs.HasKey("setupDamage")) InputDamage.text = PlayerPrefs.GetString("setupDamage");
        if (PlayerPrefs.HasKey("setupShapes")) InputShapes.text = PlayerPrefs.GetString("setupShapes");
    }

    public void ResetSettings() {
        ResetSpeed();
        ResetRows();
        ResetProgress();
    }

    public void ResetSpeed() {
        InputStartSpeed.text = defStartSpeed.ToString();
        InputSpeedProgress.text = defSpeedProgress.ToString();
    }
    public void ResetRows() {
        InputNumberRow.text = defNumberRow.ToString();
        InputShapes.text = defShapes.ToString();
    }
    public void ResetProgress() {
        InputProgress.text = defProgress.ToString();
        InputDamage.text = defDamage.ToString();        
    }

    public void Exit() {
        Application.Quit();
    }
}
