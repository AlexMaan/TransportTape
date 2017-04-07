using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodParam : MonoBehaviour {

    public int ShapeIndex;
    public int ColorIndex;
    public int SymbolIndex;

    public bool greyShaped;
    public bool greyColored;    
    
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

    public void GreyColor() {
        GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 0.7f);
        ColorIndex = 10;
        greyColored = true;
    }       
    
    public void GreyShape() {
        GetComponent<SpriteRenderer>().sprite = GoodsParamsHolder.shapes[15];
        greyShaped = true;
    } 
}
