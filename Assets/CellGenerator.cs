using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGenerator : MonoBehaviour {

    public static float genOffset;
    public static int genMode;
    public static int genRowsCount;

    public GameObject cell;
    public CellPoinerArray[] cellArrays;
    public float genPointX;
    public float genOffsetBasic;
    public int genModeBasic;

    void Awake() {
        genOffset = genOffsetBasic;
        genMode = genModeBasic;
    }



    void Update () {
        if (transform.position.x <= genPointX ) { Generation(); }
	}

    void Generation() {
        //switch (genMode) {
        //    case 1:
        //        CellPatternOne();
        //        break;
        //    default:
        //        CellPatternOne();
        //        break; }

        CellPatternOne();
        transform.Translate(genOffset, 0, 0);
    }

    void CellPatternOne(){
        StartCoroutine("CellGeneration");
        genRowsCount++;        
    }

    IEnumerator CellGeneration(){
        foreach (Transform spawn in cellArrays[genMode].cellSpawns) {
            Instantiate(cell, spawn.position, Quaternion.identity, transform.parent.transform);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
