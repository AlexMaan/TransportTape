using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodParam : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteRendererSymbol;

    public int ShapeIndex;
    public int ColorIndex;
    public int SymbolIndex;

    public bool greyShaped;
    public bool greyColored;

    public int ScaleIndex = 1;
    public int scaleCounter = 1;
    //public int maxScale = 3;
    public int currentScale;   
    
    void Awake() {
        switch (SymbolIndex) {
            case 0: ShapeIndex = Random.Range(0, 8);
                break;
            case 1: ShapeIndex = Random.Range(8, 12);
                break;
            case 2: ShapeIndex = 16; // ShapeIndex = Random.Range(16, 17);
                break;
            default: break;}
        ColorIndex = Random.Range(0, GoodsParamsHolder.colors.Length);

        spriteRenderer.sprite = GoodsParamsHolder.shapes[ShapeIndex];
        spriteRenderer.color = GoodsParamsHolder.colors[ColorIndex];
        spriteRendererSymbol.sprite = GoodsParamsHolder.symbols[SymbolIndex];

        currentScale = scaleCounter;
        if (Random.Range(0f, 1f) < 0.2f) { scaleCounter = 2; ScaleUpdater(); }
        else spriteRenderer.gameObject.transform.position += new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
    }

    private void Update() {
        if (scaleCounter != currentScale)  ScaleUpdater();
        if (ScaleIndex == 3) Destroy(gameObject, 0.8f);
    }

    void OnMouseDown() {
        //print("clicked");
        ClickPicker.SwithClicks(this);        
    }

    public void GreyColor() {
        spriteRenderer.color = new Color(0.6f, 0.6f, 0.6f, 0.7f);
        ColorIndex = 10;
        greyColored = true;
    }       
    
    public void GreyShape() {
        spriteRenderer.sprite = GoodsParamsHolder.shapes[15];
        ShapeIndex = 15;
        greyShaped = true;
    }      

    void ScaleUpdater() {        
        scaleCounter = scaleCounter > 4 ? 4 : scaleCounter;
        scaleCounter = scaleCounter < 1 ? 0 : scaleCounter;
        switch (scaleCounter) {
            case 2:
                ScaleIndex = 2;
                spriteRenderer.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
                break;
            case 3:
                goto case 2;
            case 4:
                ScaleIndex = 3;
                spriteRenderer.transform.localScale = new Vector3(1.8f, 1.8f, 1.8f);
                break;
            default:
            break;
        }
        currentScale = scaleCounter;      
    }
}
