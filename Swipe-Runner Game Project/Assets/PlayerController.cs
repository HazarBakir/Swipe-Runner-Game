using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10f;
    [SerializeField] float _jumpSpeed;
    [SerializeField] Rigidbody rbody;
    [SerializeField] bool onGround;
    void Start()
    {
        rbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 forwardForce = Vector3.forward * _speed * Time.deltaTime;
        Vector3 jumpForce = Vector3.up * _jumpSpeed;
        transform.Translate(forwardForce);
        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rbody.AddForce(jumpForce, ForceMode.Impulse);
        }

    }

    private void FixedUpdate()
    {
        if(rbody.velocity.y < 0)
        {
            rbody.velocity += Vector3.up * Physics.gravity.y * 2.0f * Time.deltaTime;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
