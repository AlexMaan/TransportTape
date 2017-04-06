using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsParamsHolder : MonoBehaviour {

    public static Sprite[] shapes;
    public static Color[] colors;
    public static Sprite[] symbols;

    public Sprite[] shapesBase;
    public Color[] colorsBase;
    public Sprite[] symbolsBase;

    void Awake() {
        shapes = shapesBase;
        colors = colorsBase;
        symbols = symbolsBase;
    }
}
