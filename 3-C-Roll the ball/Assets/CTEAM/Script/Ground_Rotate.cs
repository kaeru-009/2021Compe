using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Rotate : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;

    private float RotateV;
    private float RotateH;

    private float katamuki_move_V;
    private float katamuki_move_H;
    private float bauck_move_V;
    private float bauck_move_H;

    //FPS管理
    int freamCount;
    float prevTime;
    float fps;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;//フレーム変更
        bauck_move_V = 0.5f;
        bauck_move_H = 0.5f;
        katamuki_move_V = 0.3f;
        katamuki_move_H = 0.3f;
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
            //入力されていない時かつ戻す量が0になってない時
            if (RotateH != 0 || RotateV != 0)
            {
                if (RotateH > 0)
                {
                    RotateH -= bauck_move_H;
                }
                else if (RotateH < 0)
                {
                    RotateH += bauck_move_H;
                }

                if (RotateV > 0)
                {
                    RotateV -= bauck_move_V;
                }
                else if (RotateV < 0)
                {
                    RotateV += bauck_move_V;
                }
            }
        }

        Quaternion rotate = Quaternion.Euler(RotateV, 0, -RotateH);
        this.transform.rotation = rotate;
    }
}