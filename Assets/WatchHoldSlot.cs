using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchHoldSlot : MonoBehaviour {

    HoldSlot holdSlot;
    GoodParam thisGood;
    public static bool moved = false;


	void Start () {
        holdSlot = FindObjectOfType<HoldSlot>();
        thisGood = GetComponent<GoodParam>();
	}

    /*void Update(){
        if (moved)
            if (holdSlot.holdingGoods.Contains(thisGood)) {
                //if(!transform.IsChildOf(holdSlot.transform))
                //int i = 0;
                //foreach (GoodParam good in holdSlot.holdingGoods) {
                //    if (thisGood == good) { holdSlot.holdingGoods[i] = null; print(i); moved = false; }
                //    else i++;
                //}      
                holdSlot.holdingGoods.Remove(thisGood);
                moved = false;
            }
    }
    */
}
