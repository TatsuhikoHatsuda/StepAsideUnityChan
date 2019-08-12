using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    // carPrefabを入れる
    public GameObject carPrefab;
    // coinPrefabを入れる
    public GameObject coinPrefab;
    // conePrefabを入れる
    public GameObject conePrefab;

    // unitychanのオブジェクト
    private GameObject unitychan;

    // スタート地点
    private int startPos = -160;
    // ゴール地点
    private int goalPos = 120;
    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    // 最後に生成したアイテムの地点
    private float lastItemPos;

	// Use this for initialization
	void Start () {

        // unitychanオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        // 最初にアイテムを生成する位置を設定
        this.lastItemPos = this.startPos;
	}
	
	// Update is called once per frame
	void Update () {
        // unitychanの約50m前方に15m間隔でアイテムを生成
        if ((this.unitychan.transform.position.z + 50) - this.lastItemPos > 15 && this.unitychan.transform.position.z + 50 <= this.goalPos) {
            // どのアイテムを出すのかランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2) {
                // コーンをx軸方向に一直線に生成
                for (float i = -1; i <= 1; i += 0.4f) {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * i, cone.transform.position.y, this.unitychan.transform.position.z + 50);
                }
            }
            else {
                // レーンごとにアイテムを生成
                for (int i = -1; i <= 1; i++) {
                    // アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    // アイテムをおくz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    // 60%コイン配置：30%車配置：10%何もなし
                    if (1 <= item && item <= 6) {
                        // コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * i, coin.transform.position.y, this.unitychan.transform.position.z + 50 + offsetZ);
                    }
                    else if (7 <= item && item <= 9) {
                        // 車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * i, car.transform.position.y, this.unitychan.transform.position.z + 50 + offsetZ);
                    }
                }
            }

            // 最後に生成したアイテムの地点を更新
            this.lastItemPos = this.unitychan.transform.position.z + 50;
        }
	}
}
