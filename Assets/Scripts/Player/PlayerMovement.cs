using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController c;
    public float MovementSpeed;
    Vector3 velocity;
    public PlayerController pc;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       if (!pc.Shopping) MovePlayer(); 
    }

    private void MovePlayer()
    {
        if (pc.canlook)
        {
            float forward = Input.GetAxis("Horizontal");
            float left = Input.GetAxis("Vertical");
            Vector3 move = transform.right * forward + transform.forward * left;
            c.Move(move * MovementSpeed * Time.deltaTime);
            velocity.y += gravity;

            c.Move(-velocity);
        }
    }
}
