using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour{
    [SerializeField] private float movSpeed = 2.5f;
    [SerializeField] private float rotSpeed = 1.0f;

    private float rotation;
    private Vector3 transl_H;
    private Vector3 transl_V;
    private Vector3 move;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        move = Vector3.zero;
    }

    // Update is called once per frame
    void Update(){
        transl_H = Input.GetAxis("Horizontal") * transform.right;
        transl_V = Input.GetAxis("Vertical") * transform.forward;
        //print(transform.right);
        //print(transform.rotation.y);
        //print(Mathf.Sin(transform.rotation.y));
        //print(Mathf.Cos(transform.rotation.y));
        rotation = Input.GetAxis("Camera") * rotSpeed * Time.deltaTime;
        //if(move != Vector3.zero)
        //    move = move.normalized * movSpeed;
        move = (transl_H + transl_V).normalized;
        rb.velocity = move * movSpeed;
        transform.Rotate(0, rotation, 0);
    }
}
