using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float Speed;
    public float Jump;
    public float Walks;
    bool Facingright;
    bool Grounded;
    bool nhayr;
   


    Rigidbody2D body;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Facingright = true;
    }

   
    
    // Update is called once per frame
    void FixedUpdate()
    {   //lệnh này bắt người chơi nhập phím để di chuyển 
        float Dibo = Input.GetAxis("Horizontal");
        anim.SetFloat ("Walk", Mathf.Abs (Dibo));
        body.velocity = new Vector2(Dibo * Walks, body.velocity.y);

        if (Input.GetKey(KeyCode.Space)) {
            anim.SetBool("Jumps", true);
            if (Grounded)// lệnh này người chơi chỉ có thể nhảy khi tiếp đất
            {
                Grounded = false;
                body.velocity = new Vector2(body.velocity.x, Jump);
            }
        
        }
        
       
       
    }

    void OnCollisionEnter2D(Collision2D orther)
    {// lệnh này chỉ cho phép người chơi khi chạm đất mới được nhảy tiếp

        if (orther.gameObject.tag == "Ground")
        {
            Grounded = true;
            anim.SetBool("Jumps", false);// lệnh này cho phép khi chạm đất sẽ từ anim nhảy về ilde
        }
    }


}