using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Rotate : MonoBehaviour
{
    private float Horizontal;//水平
    private float Vertical;//垂直

    private float RotateV;//回転垂直
    private float RotateH;//回転水平

    private float katamuki_move_V;//傾ける量　垂直
    private float katamuki_move_H;//傾ける量　水平

    private float bauck_move_V;//戻す量 垂直
    private float bauck_move_H;//戻す量 水平

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//フレーム変更
        bauck_move_V = 0.5f;// 1/60
        bauck_move_H = 0.5f;// 1/60
        katamuki_move_V = 0.3f;// 1/90
        katamuki_move_H = 0.3f;// 1/90
    }


    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        //入力されているか
        if (Horizontal != 0 || Vertical != 0)//入力されてたら
        {

            if (Horizontal > 0) //(水平)右入力
            {
                RotateH += katamuki_move_H; ;
            }
            else if (Horizontal < 0) //(水平)左入力
            {
                RotateH -= katamuki_move_H; ;
            }

            if (Vertical > 0)//(垂直) 上入力
            {
                RotateV += katamuki_move_V; ;
            }
            else if (Vertical < 0)//(垂直) 下入力
            {
                RotateV -= katamuki_move_V; ;
            }

            //回転移動制御

            //垂直
            if (RotateV > 30)//正 
            {
                RotateV = 30;
            }
            else if (RotateV < -30)//負
            {
                RotateV = -30;
            }

            //水平
            if (RotateH > 30)//正
            {
                RotateH = 30;
            }
            else if (RotateH < -30)//負
            {
                RotateH = -30;
            }

        }
        else//入力されていない時
        {
            //戻す量が1より多い時
            if (RotateH > 1)
            {
                //水平方向
                if (RotateH > 0)//左に戻す
                {
                    RotateH -= bauck_move_H;
                }
            }
            else if (RotateH < -1)
            {
                if (RotateH < 0)//右に戻す
                {
                    RotateH += bauck_move_H;
                }
            }
            else
            {
                RotateH = 0;//戻す量を0にする
            }


            //戻す量が1より多い間
            if (RotateV > 1)
            {
                //垂直方向
                if (RotateV > 0)
                {
                    RotateV -= bauck_move_V;//左に戻す
                }
            }
            else if (RotateV < -1)
            {//戻す量が -1より小さい時
                if (RotateV < 0)
                {
                    RotateV += bauck_move_V;//右に戻す
                }
            }
            else
            {
                RotateV = 0;//戻す量を0にする
            }

        }

        Quaternion rotate = Quaternion.Euler(RotateV, 0, -RotateH);///回転を生成
        this.transform.rotation = rotate;//回転を更新
    }
}