using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGravity : MonoBehaviour
{
    //変数を作る
    Rigidbody2D rb;
    [SerializeField] float bombGravity;
 
    void Start()
    {
        //Rigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
    }
 
    //一秒間に一定の回数呼ばれる
    void FixedUpdate()
    {
        //自分で作った重力
        Vector2 myGravity = new Vector2(0, -bombGravity);
 
        //Rigidbody2Dに重力を加える
        rb.AddForce(myGravity);
 
    }
}
