using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchSlot : MonoBehaviour {

    public int slotType;
    public GameObject slotInstance;
    GoodsParamsHolder goodParams;
    HelpSlot helpSlot;
    public SpriteRenderer spriteRen;
    public int slotCopacity;
    public int slotFilling;
    public int slotShapeIndex;
    public int slotColorIndex;

    void Awake() {
        goodParams = FindObjectOfType<GoodsParamsHolder>();
        helpSlot = FindObjectOfType<HelpSlot>();
        slotCopacity = Random.Range(10, 20);
        slotType = Random.Range(1, 3);
        
        if(slotType == 1) {
            int shape = Random.Range(0, 8);
            spriteRen.sprite = goodParams.shapesBase[shape];
            slotShapeIndex = shape;
            slotColorIndex = 100;
        }
        else {
            int color = Random.Range(0, goodParams.colorsBase.Length);
            slotShapeIndex = 100;
            slotColorIndex = color;
            spriteRen.color = goodParams.colorsBase[color];
            spriteRen.sprite = goodParams.shapesBase[5];
            spriteRen.transform.localScale *= 1.2f;
        }

        transform.parent = helpSlot.transform;
        helpSlot.existSlots.Add(this);
        transform.position = helpSlot.slotPositions[helpSlot.existSlots.IndexOf(this)].position;

        //InvokeRepeating("Filling", 1, 1); //test
    }

    public void Filling() {
        slotFilling++;
        transform.localScale *= 1 - (0.6f / slotCopacity);
        if (slotFilling >= slotCopacity) Invoke("RemoveSlot", 0.5f);
    }

    void RemoveSlot() {        
        helpSlot.existSlots.Remove(this);
        foreach (MatchSlot slot in helpSlot.existSlots) {
            slot.transform.position = helpSlot.slotPositions[helpSlot.existSlots.IndexOf(slot)].position;
        }
        helpSlot.InstSlot();
        Destroy(gameObject);

    }

    void OnMouseDown() {
        if (ClickPicker.active != null)
            helpSlot.CompareWithHelpSlot(ClickPicker.active.gameObject);
    }
}
