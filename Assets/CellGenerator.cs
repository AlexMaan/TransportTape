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

    public float cellPosOffset;

    public List<GameObject> emptyCells = new List<GameObject>();

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
    }

    IEnumerator CellGeneration(){
        foreach (Transform spawn in cellArrays[genMode].cellSpawns) {
            GameObject cellObj = Instantiate(cell, spawn.position - new Vector3(0, 0, -0.05f), Quaternion.identity, transform.parent.transform);
            cellObj.GetComponent<Cell>().rowNumber = genRowsCount;
            yield return new WaitForSeconds(cellPosOffset);
        }
        genRowsCount++;
    }
}
