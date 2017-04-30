using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGoodReposition : MonoBehaviour {

    CellGenerator cellGen;
    GameObject targetCell;

    void Awake() {
        cellGen = GetComponent<CellGenerator>();
    }

    public void GoodReposition() {
        float xLast = 0;
        foreach (GameObject cell in cellGen.emptyCells){            
            if (ClickPicker.active != null && cell != null) {
                float x = ClickPicker.active.transform.position.x - cell.transform.position.x;
                if (x < xLast) { targetCell = cell; xLast = x; }
            }
        }
        if (targetCell != null && ClickPicker.active != null)
            StartCoroutine(GoodFly(targetCell.transform.position));
        WatchHoldSlot.moved = true;

    }

    IEnumerator GoodFly(Vector3 targetPos) {
        Vector3 goodPos = ClickPicker.active.transform.position;
        while (Vector3.Distance(goodPos, targetPos) > 0.1f)
        {
            goodPos = Vector3.Lerp(goodPos, targetPos, 0.3f);
            ClickPicker.active.transform.position = goodPos;
            yield return null;
        }
        ClickPicker.active.transform.position = targetPos;
        ClickPicker.active.transform.SetParent(targetCell.transform);
        targetCell = null;
        ClickPicker.active.GetComponent<Animator>().SetTrigger("stop");
        ClickPicker.active = null;
        yield break;
    }
}
