using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dichuyen : MonoBehaviour
{
    public float speed;
    public float Jumpshigh;
    bool facingright;
    bool grounded;

    Rigidbody2D body;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingright = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Run", Mathf.Abs(move));
        body.velocity = new Vector2(move * speed, body.velocity.y);

        // dieu kien cua flip de co the cho nhan vat quay mat ra sau lung
        if (move > 0 && !facingright)
            {
                flip();
            }
        else if (move < 0 && facingright)
            {
                flip();
            }

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                body.velocity = new Vector2(body.velocity.x, Jumpshigh);

            }
        }
        
    }
    void flip()
        {// code cho nhan vat quay mat ra sau lung khi di lui
            facingright = !facingright;
            Vector3 Thescale = transform.localScale;
            Thescale.x *= -1;
            transform.localScale = Thescale;
        }
    void OnCollisionEnter2D(Collision2D other )
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }


}

