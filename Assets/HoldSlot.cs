﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldSlot : MonoBehaviour {

    public List<GoodParam> holdingGoods = new List<GoodParam>();
    public Transform[] goodPositions = new Transform[3];

    void OnMouseDown() {
        if (ClickPicker.active != null && !ClickPicker.active.transform.IsChildOf(transform))
            PlacingGood();
    }

    public void PlacingGood() {
        //int i = 0;
        //foreach(GoodParam good in holdingGoods) {
        //    if (good == null) {
        //        holdingGoods[i] = ClickPicker.active;
        //        StartCoroutine(GoodFlyToHoldSlot(ClickPicker.active, goodPositions[i]));
        //        break; }
        //    else i++;
        //}
        GoodParam holdGood = ClickPicker.active;
        holdingGoods.Add(holdGood);
        int i = holdingGoods.IndexOf(holdGood);        
        if (i <= goodPositions.Length - 1) StartCoroutine(GoodFlyToHoldSlot(holdGood, goodPositions[i]));
        else holdingGoods.Remove(holdGood);
    }

    IEnumerator GoodFlyToHoldSlot(GoodParam good, Transform slot) {
        good.spriteRenderer.transform.position = good.spriteRenderer.transform.parent.transform.position;
        float timeStamp = 0;
        while (Vector3.Distance(good.transform.position, slot.position) > 0.1) {
            good.transform.position = Vector3.Lerp(good.transform.position, slot.position, 0.3f);
            timeStamp += Time.deltaTime;
            if (timeStamp >= 0.4f) break;                      
            yield return null;
        }
        good.GetComponent<Animator>().SetTrigger("stop");
        good.transform.parent = transform;
        good.transform.position = slot.position + new Vector3(0, 0, -0.1f);
        ClickPicker.active = null;        
    }

    int childNlast;
    void Awake() {
        childNlast = transform.childCount;
    }

    void Update() {
        if (transform.childCount != childNlast ) {
            print("childChange");
            int i = 0;
            foreach (GoodParam good in holdingGoods) {
                if (good == null) { holdingGoods.Remove(good); break; }
                if (!good.transform.IsChildOf(transform)) { holdingGoods.Remove(good); break; }
                }
            foreach (GoodParam good in holdingGoods) {
                good.transform.position = goodPositions[i].position + new Vector3(0, 0, -0.1f); ;
                i++;
                print("cool");
                }
                childNlast = transform.childCount;
        }
    }


}
