using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageMarks : MonoBehaviour {

    public Slider slider;
    int[] marks = { 1, 2, 3, 4, 5 };
    public GameObject[] marksObj;
    public float lastBarValue = 0;
    public float actualBarValue = 0;


	void Start () {
        lastBarValue = 0;
	}
	
	void Update () {
        actualBarValue = slider.value;
        foreach (int i in marks) {
            if (lastBarValue <= (i * 40) - 10 && actualBarValue > (i * 40) - 10) { LightMark(i); break; }
        }
        lastBarValue = actualBarValue;
	}

    void LightMark(int markN) {
        for (int i = 1; i <= markN; i++) {
            marksObj[markN - 1].GetComponent<Animator>().SetTrigger("on");
        }
    }
}
