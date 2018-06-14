using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour {

    public new Camera camera;

    public float speed;
    public float jumpForce;
    public KeyCode forwards;
    public KeyCode left;
    public KeyCode right;
    public KeyCode backwards;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        Vector3 toMove = new Vector3(0f, rb.velocity.y, 0f);

        bool NS = false;
        bool EW = false;

        if (Input.GetKey(forwards))
        {
            toMove += new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z) * speed;
            NS = !NS;

        }

        if (Input.GetKey(backwards))
        {
            toMove += new Vector3(-camera.transform.forward.x, 0, -camera.transform.forward.z) * speed;
            NS = !NS;
        }

        if (Input.GetKey(left))
        {
            toMove += new Vector3(-camera.transform.right.x, 0, -camera.transform.right.z) * speed;
            EW = !EW;
        }

        if (Input.GetKey(right))
        {
            toMove += new Vector3(camera.transform.right.x, 0, camera.transform.right.z) * speed;
            EW = !EW;
        }

        //Makes diagonals just as quick as moving in just one axis
        if(NS && EW)
        {
            toMove = new Vector3(toMove.x / Mathf.Sqrt(2), 0, toMove.z / Mathf.Sqrt(2));
        }

        /*
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        */

        rb.velocity = toMove;
    }
}
