using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 10F;
    Rigidbody2D rigidbody;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnDisable() 
    {
        SceneManager.LoadScene(0);
    }
    
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(h,v);
        rigidbody.velocity = dir.normalized * speed;

        animator.SetBool("IsFlyingLeft", (h < 0));
        animator.SetBool("IsFlyingRight", (h > 0));
        animator.SetBool("IsFlyingUp", (v > 0));

        //GetComponent<Animator>().SetBool("IsFlyingLeft", (h < 0));
        //GetComponent<Animator>().SetBool("IsFlyingRight", (h > 0));
        //GetComponent<Animator>().SetBool("IsFlyingUp", (v > 0));
    }
}
