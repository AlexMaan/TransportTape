using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpSlot : MonoBehaviour {

    public List<MatchSlot> existSlots = new List<MatchSlot>();
    public Transform[] slotPositions;       
    public GameObject slotInstance;
    public int slotPoints;

    void Start() {
        InstSlot();
        InstSlot();
    }

    public void InstSlot() {
        Instantiate(slotInstance);
    }

    public void CompareWithHelpSlot() {
        GameObject tile = null;
        if (ClickPicker.active != null) tile = ClickPicker.active.gameObject;
        foreach (MatchSlot slot in existSlots) {
            if (slot.slotShapeIndex == tile.GetComponent<GoodParam>().ShapeIndex || slot.slotColorIndex == tile.GetComponent<GoodParam>().ColorIndex) {
                //print("match");
                CollectGood(tile, slot);
                tile.transform.SetParent(transform.root);
                StartCoroutine(GoodFly(tile, slot));                
                break;
            }
            else {
                //print("do not match");
                ClickPicker.active = null;
                tile.GetComponent<Animator>().SetTrigger("stop");
            }
        }
    }
    
    void CollectGood (GameObject tile, MatchSlot slot) {
        slot.Filling();
        ProgressWheel.levelProgress += slotPoints * tile.GetComponent<GoodParam>().ScaleIndex;
    }

    IEnumerator GoodFly(GameObject good, MatchSlot slot) {
        while (Vector3.Distance(good.transform.position, slot.transform.position) > 0.1f)
        {
            good.transform.position = Vector3.Lerp(good.transform.position, slot.transform.position, 0.3f);
            yield return null;
        }
        Destroy(good.gameObject);        
        ClickPicker.active = null;
    }
}
