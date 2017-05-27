using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorSpritesHolder {

    public Sprite[] artSpriteColors;
}

[System.Serializable]
public class ShapeSpriteHolder {

    public ColorSpritesHolder[] artSpriteShapes;
}

    public class AtrGoodSprite : MonoBehaviour {

    public ShapeSpriteHolder[] artSpriteStyles;
    int style;
    GoodParam goodParam;
    SpriteRenderer sprite;
	
    void Start() {
        goodParam = transform.GetComponentInParent<GoodParam>();
        sprite = GetComponent<SpriteRenderer>();
        style = PlayerPrefs.GetInt("LevelStyle");
        SetSprite();
    }

    public void SetSprite() {
        sprite.sprite = artSpriteStyles[style].artSpriteShapes[goodParam.ShapeIndex].artSpriteColors[goodParam.ColorIndex];
    }
}
