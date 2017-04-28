﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    public int rowNumber;
    CellGenerator cellGen;
    bool isEmpty;

    void Awake () {
        //if (Mathf.Repeat(GoodsMixer.genGoodCount, 2) > 0) // pattern maker
        Vector3 randomPos = gameObject.transform.position; // + new Vector3(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f), 0); //random good pos offset
        Instantiate(GoodsMixer.activeGood, randomPos + new Vector3(0,0,-0.1f), Quaternion.identity, gameObject.transform);
        GoodsMixer.genGoodCount++;

        cellGen = FindObjectOfType<CellGenerator>();
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Destroyer")) Destroy(gameObject);
    }

    private void OnMouseDown() {
        if (GetComponentInChildren<GoodParam>() == null && ClickPicker.active != null) {
            ClickPicker.active.transform.position = transform.position + new Vector3(0, 0, -0.5f);
            ClickPicker.active.transform.parent = transform;
            ClickPicker.active.GetComponent<Animator>().SetTrigger("stop");
            ClickPicker.active = null;
            WatchHoldSlot.moved = true;
        }
    }

    private void Update() {
        if (!isEmpty && transform.childCount == 0) { cellGen.emptyCells.Add(gameObject); isEmpty = true; }
        if (isEmpty && transform.childCount != 0) { cellGen.emptyCells.Remove(gameObject); isEmpty = false; } 
    }
}
