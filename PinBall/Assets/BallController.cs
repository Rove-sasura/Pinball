using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //�{�[����������\���̂���z���̍ő�l
    private float visiblePosZ = -6.5f;

    //�Q�[���I�[�o��\������e�L�X�g
    private GameObject gameoverText;

    //�X�R�A��\������e�L�X�g
    private GameObject scoreText;

    //���_
    private int score = 0;

    // Use this for initialization
    void Start()
    {
        //�V�[������GameOverText�I�u�W�F�N�g���擾
        this.gameoverText = GameObject.Find("GameOverText");

        //�V�[������scoreText�I�u�W�F�N�g���擾
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //�{�[������ʊO�ɏo���ꍇ
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverText�ɃQ�[���I�[�o��\��
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallCloudTag")
        {
            //���_10�_
            score += 10;
        }
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            //���_20�_
            score += 20;
        }
        if (collision.gameObject.tag == "LargeStarTag")
        {
            //���_5�_
            score += 5;
        }

        //ScoreText�l�������_����\��
        this.scoreText.GetComponent<Text>().text = "Score " + this.score;

    }
}
