﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Rotate : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;

    private float RotateV;
    private float RotateH;

    [SerializeField]private float backVal_V;
    [SerializeField]private float backVal_H;


    //FPS管理
    int freamCount;
    float prevTime;
    float fps;

    // Start is called before the first frame update
    void Start()
    {
        freamCount = 0;
        prevTime = 0.0f;

        Application.targetFrameRate = 60;//フレーム変更
        backVal_V = 0.5f;
        backVal_H = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        freamCount++;//フレームカウント
        float time = Time.realtimeSinceStartup - prevTime;//ゲームスタートした経過時間

        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        //入力されているか
        if (Horizontal != 0 || Vertical != 0)//入力されてたら
        {
            
            if (Horizontal > 0) //(水平)右入力
            {
                RotateH += 0.5f;
            }else if (Horizontal < 0) //(水平)左入力
            {
                RotateH -= 0.5f;
            }

            if (Vertical > 0)//(垂直) 上入力
            {
                RotateV += 0.5f;
            }
            else if (Vertical < 0)//(垂直) 下入力
            {
                RotateV -= 0.5f;
            }

            //回転移動制御

            //垂直
            if (RotateV > 30)//正 
            {
                RotateV = 30;
            }else if(RotateV < -30)//負
            {
                RotateV = -30;
            }

            //水平
            if (RotateH > 30)//正
            {
                RotateH = 30;
            }else if (RotateH < -30)//負
            {
                RotateH = -30;
            }
            
        }
        else//入力されていない時
        {
            //入力されていない時かつ戻す量が0になってない時
            if (RotateH != 0 || RotateV != 0) {
                if (RotateH > 0)
                {
                    RotateH -= backVal_H;
                }
                else if (RotateH < 0)
                {
                    RotateH += backVal_H;
                }

                if (RotateV > 0)
                {
                    RotateV -= backVal_V;
                }
                else if (RotateV < 0)
                {
                    RotateV += backVal_V;
                }
            }

            Debug.Log(RotateH);
        }

        Quaternion rotate = Quaternion.Euler(RotateV, 0, -RotateH);
        this.transform.rotation = rotate;
    }
}
