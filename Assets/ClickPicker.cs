using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPicker : MonoBehaviour {

    public static GoodParam active;
    public static GoodParam lastClicked;
    public static GoodParam beforeLastClicked;       

    public static void SwithClicks(GoodParam current) {
        if (active != null && lastClicked != null ) {
            beforeLastClicked = lastClicked;
            lastClicked = active;
            active = current;
            PlayAmins();
        }
        else if (active != null) {
            lastClicked = active;
            active = current;
            PlayAmins();
        }
        else { active = current; PlayAmins(); }
        }

    static void PlayAmins(){
        active.GetComponent<Animator>().SetTrigger("idle");
        if(lastClicked != null)
        lastClicked.GetComponent<Animator>().SetTrigger("stop");
    }

    // Preview
    //public GoodParam activeV;
    //public GoodParam lastClickedV;
    //public GoodParam beforeLastClickedV;

    //void Update() {
    //    activeV = active;
    //    lastClickedV = lastClicked;
    //    beforeLastClickedV = beforeLastClicked;
    //}
}
