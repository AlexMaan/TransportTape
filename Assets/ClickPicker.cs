using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPicker : MonoBehaviour {

    public static GoodParam active;
    public static GoodParam lastClicked;
    public static GoodParam beforeLastClicked;

    public delegate void GoodClick();
    public static event GoodClick goodIsClicked;

    static GoodParam currentGood;

    void Awake() {
        goodIsClicked += ClickLogic;
    }


    public static void SwithClicks(GoodParam current) {
        currentGood = current;
        if (current == active && active != null) { active = null; current.GetComponent<Animator>().SetTrigger("stop"); }  
        else {
            if (active != null && lastClicked != null) {
                beforeLastClicked = lastClicked;
                lastClicked = active;
                active = current;
                PlayAmins(); }

            else if (active != null) {
                lastClicked = active;
                active = current;
                PlayAmins(); }
            else {
                active = current;
                PlayAmins(); }

            if (goodIsClicked != null) goodIsClicked();
        }
    }

    static void PlayAmins(){
        active.GetComponent<Animator>().SetTrigger("idle");
        if(lastClicked != null)
        lastClicked.GetComponent<Animator>().SetTrigger("stop");
    }

    void ClickLogic() {
        if (lastClicked != null) {
            if (active.ShapeIndex == lastClicked.ShapeIndex && active.ColorIndex == lastClicked.ColorIndex) SymbolSwith(3);
            else if (active.ShapeIndex == lastClicked.ShapeIndex) SymbolSwith(2);
            else if (active.ColorIndex == lastClicked.ColorIndex) SymbolSwith(1);
            else if (active.ShapeIndex != lastClicked.ShapeIndex && active.ColorIndex != lastClicked.ColorIndex ) SymbolSwith(0);
        }
    }
    void SymbolSwith(int matchIndex) {
        if(active.SymbolIndex == lastClicked.SymbolIndex) {
            switch (active.SymbolIndex){
                case 0: CubeSwitch(matchIndex);
                    break;
                case 1: BoostSwitch(matchIndex);
                    break;
                case 2: BombSwitch(matchIndex);
                    break;
                    default: break;
            }
        }
    }
    void CubeSwitch(int matchIndex) {
        if (currentGood.greyShaped == lastClicked.greyShaped && currentGood.greyColored == lastClicked.greyColored){
            StartCoroutine(CombineGoodFly(lastClicked));
            if (lastClicked.transform.parent.localScale != Vector3.one) active.transform.parent.localScale *= 1.5f;
            switch (matchIndex) {
                case 0:
                    if (currentGood.greyShaped == lastClicked.greyShaped && currentGood.greyColored == lastClicked.greyColored) {
                        currentGood.GreyColor(); currentGood.GreyShape();
                    }
                    break;
                case 1:
                    currentGood.GreyShape();
                    break;
                case 2:
                    currentGood.GreyColor();
                    break;
                case 3:

                    break;
                default: break;
            }
        }
    }

    void BoostSwitch(int matchIndex) {

    }

    void BombSwitch(int matchIndex) {

    }

    IEnumerator CombineGoodFly(GoodParam flyer) {
        while (Vector3.Distance(flyer.transform.position, active.transform.position) > 1) {
            flyer.transform.position = Vector3.Lerp(flyer.transform.position, active.transform.position, 0.2f);
            yield return null;
        }
        Destroy(flyer.gameObject);
        active = null;
        currentGood.GetComponent<Animator>().SetTrigger("stop");
    }
}

// Clicks Preview
//public GoodParam activeV;
//public GoodParam lastClickedV;
//public GoodParam beforeLastClickedV;

//void Update() {
//    activeV = active;
//    lastClickedV = lastClicked;
//    beforeLastClickedV = beforeLastClicked;
//}
