using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPicker : MonoBehaviour {

    public static int plusPoints;

    public static GoodParam active;
    public static GoodParam lastClicked;
    public static GoodParam beforeLastClicked;

    public delegate void GoodClick();
    public static event GoodClick goodIsClicked;

    static GoodParam currentGood;

    void Awake() {
        goodIsClicked += ClickLogic;
        if (PlayerPrefs.HasKey("setupProgress")) plusPoints = int.Parse(PlayerPrefs.GetString("setupProgress"));
    }

    public static void SwithClicks(GoodParam current) {        
        if (current == active && active != null) { active = null; lastClicked = null; beforeLastClicked = null; current.GetComponent<Animator>().SetTrigger("stop"); }  
        else {
            currentGood = current;
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
        //    goto Function;
        //Function:
        //    print("cool");
        }
    }

    static void PlayAmins() {
        active.GetComponent<Animator>().SetTrigger("idle");
        if(lastClicked != null)
        lastClicked.GetComponent<Animator>().SetTrigger("stop");
    }

    IEnumerator CombineGoodFly(GoodParam flyer, bool isBomb) {
        flyer.transform.SetParent(transform.root);
        while (Vector3.Distance(flyer.transform.position, active.transform.position) > 1) {
            flyer.transform.position = Vector3.Lerp(flyer.transform.position, active.transform.position, 0.2f);
            yield return null;
        }
        Destroy(flyer.gameObject);
        if(!isBomb) Destroy(active.gameObject);
        active = null;
        currentGood.GetComponent<Animator>().SetTrigger("stop");
        Swiper.selectedGoods.Clear();
    }

    void ClickLogic() {
        if (lastClicked != null) {
            int i = 0;
            if (active.ShapeIndex == lastClicked.ShapeIndex && active.ColorIndex == lastClicked.ColorIndex) i = 1;
            else if (active.ShapeIndex == lastClicked.ShapeIndex) i = active.greyColored || lastClicked.greyColored ? 0 : 0;
            else if (active.ColorIndex == lastClicked.ColorIndex) i = active.greyShaped  || lastClicked.greyShaped  ? 0 : 0;
            else if (active.ShapeIndex != lastClicked.ShapeIndex && active.ColorIndex != lastClicked.ColorIndex)
                 if (!active.greyShaped && !active.greyColored && !lastClicked.greyShaped && !lastClicked.greyColored) i = 0;
                 else i = 0;
            SymbolSwith(i);
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
        switch (matchIndex) {
            case 0:
                //print("case0");
                ClicksReset();
                break;
            case 1:
                StartCoroutine(CombineGoodFly(lastClicked, false));
                //ScaleCombine();
                ProgressWheel.levelProgress += plusPoints * ((float)(active.ScaleIndex * lastClicked.ScaleIndex) / 2);
                TapeSpeedPause.pauseButtonCounter += 0.3f;
                //print("case1");
                break;
            case 2:
                StartCoroutine(CombineGoodFly(lastClicked, false));
                currentGood.GreyColor();
                ProgressWheel.levelProgress += plusPoints / 2;
                //print("case2");
                //Destroy(active.gameObject);
                //Destroy(lastClicked.gameObject);
                break;
            case 3:
                StartCoroutine(CombineGoodFly(lastClicked, false));
                currentGood.GreyShape();
                ProgressWheel.levelProgress += plusPoints / 2;
                //print("case3");
                //Destroy(active.gameObject);
                //Destroy(lastClicked.gameObject);
                break;
            case 4:
                StartCoroutine(CombineGoodFly(lastClicked, false));
                currentGood.GreyShape();
                currentGood.GreyColor();
                //print("case4");
                Destroy(active.gameObject);
                Destroy(lastClicked.gameObject);
                break;
            default: break;
        }
    }    
    void BoostSwitch(int matchIndex) {

    }
    void BombSwitch(int matchIndex) {
        switch (matchIndex)
        {
            case 0:
                print("case0");
                ClicksReset();
                break;
            case 1:
                StartCoroutine(CombineGoodFly(lastClicked, true));
                ScaleCombine();
                //print("case1");
                break;
            case 2:
                StartCoroutine(CombineGoodFly(lastClicked, true));
                currentGood.GreyColor();
                //print("case2");
                Destroy(active.gameObject);
                Destroy(lastClicked.gameObject);
                break;
            case 3:
                StartCoroutine(CombineGoodFly(lastClicked, true));
                currentGood.GreyShape();
                //print("case3");
                Destroy(active.gameObject);
                Destroy(lastClicked.gameObject);
                break;
            case 4:
                StartCoroutine(CombineGoodFly(lastClicked, true));
                currentGood.GreyShape();
                currentGood.GreyColor();
                //print("case4");
                Destroy(active.gameObject);
                Destroy(lastClicked.gameObject);
                break;
            default: break;
        }
    }
       
    void ClicksReset(){
        active.GetComponent<Animator>().SetTrigger("stop");
        lastClicked.GetComponent<Animator>().SetTrigger("stop");
        active = null;
        lastClicked = null;
        beforeLastClicked = null;
    }

    void ScaleCombine(){
        int summScale = active.scaleCounter + lastClicked.scaleCounter;
        active.scaleCounter = summScale;
    }

    // clicked obj preview

    public GoodParam currentV;
    public GoodParam activeV;
    public GoodParam lastClickedV;
    public GoodParam beforeLastClickedV;

    void Update(){
        currentV = currentGood;
        activeV = active;
        lastClickedV = lastClicked;
        beforeLastClickedV = beforeLastClicked;
    }
    
}

