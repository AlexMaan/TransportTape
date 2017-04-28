using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldSlot : MonoBehaviour {

    public GoodParam[] holdingGoods = new GoodParam[3];
    public Transform[] goodPositions = new Transform[3];

    void OnMouseDown() {
        if (ClickPicker.active != null)
            PlacingGood();
    }

    public void PlacingGood() {
        int i = 0;
        foreach(GoodParam good in holdingGoods) {
            if (good == null) {
                holdingGoods[i] = ClickPicker.active;
                StartCoroutine(GoodFlyToHoldSlot(ClickPicker.active, goodPositions[i]));
                break; }
            else i++;
        }
    }

    IEnumerator GoodFlyToHoldSlot(GoodParam good, Transform slot) {
        good.spriteRenderer.transform.position = good.spriteRenderer.transform.parent.transform.position;
        float timeStamp = 0;
        while (Vector3.Distance(good.transform.position, slot.position) > 0.1) {
            good.transform.position = Vector3.Lerp(good.transform.position, slot.position, 0.2f);
            timeStamp += Time.deltaTime;
            if (timeStamp >= 0.4f) break;                      
            yield return null;
        }
        good.GetComponent<Animator>().SetTrigger("stop");
        good.transform.parent = transform;
        good.transform.position = slot.position + new Vector3(0, 0, -0.1f);
        ClickPicker.active = null;        
    }
}
