using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGoodReposition : MonoBehaviour {

    CellGenerator cellGen;
    GameObject targetCell;

    void Awake() {
        cellGen = GetComponent<CellGenerator>();
    }

    public void GoodReposition()
    {
        foreach (GameObject cell in cellGen.emptyCells){
            if (targetCell != null && cell != null) {
                float x =  targetCell.transform.position.x - cell.transform.position.x;
                targetCell = x <= 0 ? cell : targetCell;
                }
            else targetCell = cell;
            if (targetCell != null && ClickPicker.active != null)
                StartCoroutine(GoodFly(targetCell.transform.position));
        }

    }

    IEnumerator GoodFly(Vector3 targetPos){
        //Vector3 goodPos = ClickPicker.active.transform.position;
        //while (Vector3.Distance(goodPos, targetPos) > 0.1f) {
        //    goodPos = Vector3.Lerp(goodPos, targetPos, 0.2f);
        //    ClickPicker.active.transform.position = goodPos;
        //    yield return null;
        //}
        ClickPicker.active.transform.position = targetPos;
        ClickPicker.active.transform.SetParent(targetCell.transform);
        ClickPicker.active.GetComponent<Animator>().SetTrigger("stop");
        ClickPicker.active = null;
        yield break;
    }
}
