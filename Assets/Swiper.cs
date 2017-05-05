using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiper : MonoBehaviour {

    HelpSlot helpSlot;
    HoldSlot holdSlot;
    CellGoodReposition cellGoodRepos;
    public float swipeLength;
    public static bool mousePressed;
    public static List<GoodParam> selectedGoods = new List<GoodParam>();
    public List<GoodParam> viewSelected;
    public Booster booster;


    private void Awake() {
        helpSlot = FindObjectOfType<HelpSlot>();
        holdSlot = FindObjectOfType<HoldSlot>();
        cellGoodRepos = FindObjectOfType<CellGoodReposition>();
        booster = FindObjectOfType<Booster>();
    }
                
    void SwidepUp() { if(ClickPicker.active != null) helpSlot.CompareWithHelpSlot(); }
    void SwipedDown() { if (ClickPicker.active != null) holdSlot.PlacingGood(); }
    void SwipeRight() { if (ClickPicker.active != null) cellGoodRepos.GoodReposition(); }

    void Update() {
        //Swipe();
        SwipeMouse();
        viewSelected = selectedGoods;
    }

    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void Swipe() {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);

                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                if (currentSwipe.magnitude > swipeLength)
                {

                    currentSwipe.Normalize();

                    if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        //Debug.Log("up swipe");
                        SwidepUp();
                    }
                    if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                    {
                        //Debug.Log("down swipe");
                        SwipedDown();
                    }
                    if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                    {
                        //Debug.Log("left swipe");
                    }
                    if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                    {
                        //Debug.Log("right swipe");
                        SwipeRight();
                    }
                }
            }
        }
    }
    public void SwipeMouse()
    {
        if (Input.GetMouseButtonDown(0)) {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            mousePressed = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            mousePressed = false;

            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);            

            if (currentSwipe.magnitude > swipeLength && selectedGoods.Count ==0) {

                currentSwipe.Normalize();

                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    //Debug.Log("up swipe");
                    SwidepUp();
                }
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
                    //Debug.Log("down swipe");
                    SwipedDown();
                }
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    //Debug.Log("left swipe");
                }
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
                    //Debug.Log("right swipe");
                    SwipeRight();
                }
            }

            if (selectedGoods.Count != 0) PickUpGoods();
        }
    }
    

    void PickUpGoods() {
        int goodsCollected = 0;
        Vector3 lastGoodPos = new Vector3();
        int effectN = new int();
        foreach (GoodParam good in selectedGoods) {
            if (good != null) { good.GetComponent<Animator>().SetTrigger("collect"); Destroy(good.gameObject, 0.4f); }
            goodsCollected++;
            ProgressWheel.levelProgress += 0.75f * goodsCollected;
            lastGoodPos = good.transform.position;
            effectN = good.ColorIndex;

        }
        if (ClickPicker.active.gameObject != null) { ClickPicker.active.GetComponent<Animator>().SetTrigger("collect"); Destroy(ClickPicker.active.gameObject, 0.4f); }
        selectedGoods.Clear();
        ProgressWheel.levelProgress += 0.75f;
        booster.LaunchBoostEffect(effectN, lastGoodPos, goodsCollected + 1);            
    }
}
