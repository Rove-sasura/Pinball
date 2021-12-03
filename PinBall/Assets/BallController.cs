using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //得点
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のscoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallCloudTag")
        {
            //加点10点
            score += 10;
        }
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            //加点20点
            score += 20;
        }
        if (collision.gameObject.tag == "LargeStarTag")
        {
            //加点5点
            score += 5;
        }

        //ScoreText獲得した点数を表示
        this.scoreText.GetComponent<Text>().text = "Score " + this.score;

    }
}
