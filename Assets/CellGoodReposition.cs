using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGoodReposition : MonoBehaviour {

    CellGenerator cellGen;
    GameObject targetCell;

    void Awake() {
        cellGen = GetComponent<CellGenerator>();
    }

    public void GoodReposition(GoodParam good) {
        float xLast = 0;
        foreach (GameObject cell in cellGen.emptyCells){            
            if (good != null && cell != null) {
                float x = good.transform.position.x - cell.transform.position.x;
                if (x < xLast) { targetCell = cell; xLast = x; }
            }
        }
        if (targetCell != null && good != null)
            StartCoroutine(GoodFly(good, targetCell.transform.position));
    }

    IEnumerator GoodFly(GoodParam good, Vector3 targetPos) {
        Vector3 goodPos = good.transform.position;
        good.transform.SetParent(targetCell.transform);
        targetCell = null;
        while (Vector3.Distance(goodPos, targetPos) > 0.1f)
        {
            goodPos = Vector3.Lerp(goodPos, targetPos, 30f * Time.deltaTime);
            good.transform.position = goodPos;
            yield return null;
        }
        good.transform.position = targetPos;        
        good.GetComponent<Animator>().SetTrigger("stop");
        if (ClickPicker.active = good) ClickPicker.active = null;
        yield break;
    }
}
