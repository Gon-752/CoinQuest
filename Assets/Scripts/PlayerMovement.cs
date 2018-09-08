using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    Vector3 previousLocation;

    void Awake(){
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        previousLocation = transform.position;
    }

    void FixedUpdate(){
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");

        Move(h,v);
        Turning();
        Animating(h,v);
    }

    void Move(float h, float v){
        movement.Set(h,0f,v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning(){
            if(Input.GetAxisRaw ("Horizontal") + Input.GetAxisRaw ("Vertical") != 0f){
            while(gameObject.GetComponent<PlayerFight>().fight){
                GameObject target = gameObject.GetComponent<PlayerFight>().GetTarget(movement);
                transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), Time.fixedDeltaTime * 66);
                return;
            }
            transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation(transform.position - previousLocation), Time.fixedDeltaTime * speed);
            previousLocation = transform.position;
        }
    }

    void Animating(float h, float v){
        bool walking = h != 0f || v != 0f;
        anim.SetBool ("IsWalking", walking);
    }
    //Placeholder functions for Animation events
public void Hit(){
}
public void Shoot(){
}
public void FootR(){
}
public void FootL(){
}
public void Land(){
}
public void WeaponSwitch(){
}
}
