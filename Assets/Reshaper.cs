using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reshaper : MonoBehaviour {

    GameObject baseTape;
    public GoodParam[] goods;
    public float changeRange;
    float defRange;
    float timeStapm;

    void Awake() {
        baseTape = GameObject.FindGameObjectWithTag("Tape");
        //InvokeRepeating("Go",2,2);
        defRange = changeRange;
    }

    void Update() {
        goods = baseTape.GetComponentsInChildren<GoodParam>();
        timeStapm += Time.deltaTime;
        if (timeStapm > 3) changeRange = defRange;
    }

    void Go() {
        ReshapeGoods(ClickPicker.active);
    }

    public void ReshapeGoods(GoodParam exampleGood) {
        foreach(GoodParam good in goods) {
            if(good.SymbolIndex == 0 && Random.Range(0f, 1f) < changeRange) {
                int i = Random.Range(0f, 1f) > 0.5 ? 1 : 2;
                if (i == 1) { good.ShapeIndex = exampleGood.ShapeIndex;
                    good.transform.Find("sprite").GetComponent<SpriteRenderer>().sprite = GoodsParamsHolder.shapes[good.ShapeIndex];
                    good.transform.Find("Art_sprite").transform.Find("Art_sprite").GetComponent<AtrGoodSprite>().SetSprite();
                    good.GetComponent<Animator>().SetTrigger("appear");
                }
                if (i == 2) { good.ColorIndex = exampleGood.ColorIndex;
                    good.transform.Find("sprite").GetComponent<SpriteRenderer>().color = GoodsParamsHolder.colors[good.ColorIndex];
                    good.transform.Find("Art_sprite").transform.Find("Art_sprite").GetComponent<AtrGoodSprite>().SetSprite();
                    good.GetComponent<Animator>().SetTrigger("appear");
                }
            }
        }
        changeRange -= 0.1f;
        timeStapm = 0;
    }

}
