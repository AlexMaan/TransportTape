using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodsMixer : MonoBehaviour {

    public GoodsArray[] goodsArrays;
    public static GameObject activeGood;
    public static int genGoodCount;
    int genGoodCountLast;

    bool goodsReloaded;
    public List<int> goodWeights = new List<int>();
    GoodsArray currentArray;
    public int weightUp;
    public int weightDown;


    void Awake() {
        ReloadGoods(goodsArrays[0]);
        MixGoods();
        //Invoke("MixGoods",2); //test
    }

    void LateUpdate() {
        if (genGoodCount != genGoodCountLast) {
            MixGoods();
            genGoodCountLast = genGoodCount;
        }
    }

    void ReloadGoods(GoodsArray array) {
        currentArray = array;
        for (int i = 0; i < array.goods.Length; i++) {
            int weight = Random.Range(1, 100);
            while (goodWeights.Contains(weight) && array.goods.Length <100) weight = Random.Range(1, 100);
            goodWeights.Add(weight);              
        }
    }

    void MixGoods() {
        int maxWeight = Mathf.Max(goodWeights.ToArray());
        int index = goodWeights.IndexOf(maxWeight);
        activeGood = currentArray.goods[index];

        for (int i = 0; i < goodWeights.Count; i++) { goodWeights[i] += Random.Range(0, weightUp); goodWeights[i] = goodWeights[i] > 100 ? 100 : goodWeights[i]; }
        goodWeights[index] -= (Random.Range(1, weightUp) + Random.Range(1, weightDown));
        goodWeights[index] = goodWeights[index] < 1 ? 1 : goodWeights[index];
    }
}
