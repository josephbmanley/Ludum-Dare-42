
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class collected
{
    public int number;
    public string name;
}

public class Player_Manager : MonoBehaviour {

    //Speed Variables
    public float speedBoost = 0;
    const float baseSpeed = 6f;
    public Animator animator;

    //Jump Variables
    public float jumpBoost = 0;
    const float baseJump = 750f;

    private bool touchingGround = false;
    public bool animate = true;


    //Collectables
    public float totalValue;
    public int itemCount;
    public List<collected> itemsCollected = new List<collected>();

    float getJumpMomentum()
    {
        return jumpBoost + baseJump;
    }

    float getSpeed()
    {
        return speedBoost + baseSpeed;
    }
	
	
	void Update () {
        /* =====================
           General game movement
           ===================== */
        this.GetComponent<Rigidbody2D>().AddForce(transform.right * getSpeed());
        //Jumping
        if(Input.GetKeyDown(KeyCode.Space) & touchingGround)
        {
            animator.Play("Jumpy_Jump");
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * getJumpMomentum());
        }
        else if(touchingGround == false)
        {
            animator.Play("Midair");
        }
        else
        {
            if (animate)
            {
                animator.Play("Run");
            }
            else
            {
                animator.StopPlayback();
            }
        }

        //Stop rotating if over 46 degrees
        if(this.transform.localEulerAngles.z > 46)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        if(this.transform.localEulerAngles.z < -46)
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }

    }

    /*  =================
     *  =Floor Collision=
        =================   */
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Floor")
        {
            touchingGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            touchingGround = false;
        }
    }
}
