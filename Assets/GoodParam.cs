using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodParam : MonoBehaviour {

    public int ShapeIndex;
    public int ColorIndex;
    public int SymbolIndex;    
    
    void Awake() {
        switch (SymbolIndex) {
            case 0: ShapeIndex = Random.Range(0, 8);
                break;
            case 1: ShapeIndex = Random.Range(8, 12);
                break;
            case 2: ShapeIndex = Random.Range(12, 15);
                break;
            default: break;}
        ColorIndex = Random.Range(0, GoodsParamsHolder.colors.Length);

        GetComponent<SpriteRenderer>().sprite = GoodsParamsHolder.shapes[ShapeIndex];
        GetComponent<SpriteRenderer>().color = GoodsParamsHolder.colors[ColorIndex];
        transform.GetChild(0).GetComponentInChildren<SpriteRenderer>().sprite = GoodsParamsHolder.symbols[SymbolIndex];
    }

    void OnMouseDown() {
        print("clicked");
        ClickPicker.SwithClicks(this);        
    }        
}
