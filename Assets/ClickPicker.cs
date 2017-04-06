using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPicker : MonoBehaviour {

    public static List<GoodParam> clickedObjects = new List<GoodParam>();
    public static int ClickNumb;

    public List<GoodParam> viewObjects = new List<GoodParam>();


    void Update() {

        viewObjects = clickedObjects;
        //if (clickedObjects.Count > 0)
        //    clickedObjects[clickedObjects.Count-1].gameObject.transform.localScale *= 2;
    }
}
