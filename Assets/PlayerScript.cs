using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    public Rigidbody rb;




    void Update()
    {
        if(rb.velocity == Vector3.zero)
        {
            char inpuDirection = GetInput();
            if (inpuDirection != ' ')
            {
                switch (inpuDirection)
                {
                    case 'r': direction = Vector3.right; break;
                    case 'l': direction = Vector3.left; break;
                    case 'u': direction = Vector3.forward; break;
                    case 'd': direction = Vector3.back; break;
                }
                if (direction != Vector3.zero)
                {
                    rb.AddForce(direction * speed, ForceMode.Impulse);
                }
            }
        }
    }

    Vector2 startPos;

    char GetInput()
    {
        char direction = ' ';
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Store the starting position of the touch
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                // Calculate the swipe direction based on the difference between the starting and ending positions
                Vector2 swipeDelta = touch.position - startPos;

                // Check if the swipe was a horizontal swipe (left or right)
                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    // Check if the swipe was to the right
                    if (swipeDelta.x > 0)
                    {
                        Debug.Log("Swiped right!");
                        direction= 'r';
                    }
                    // Otherwise, the swipe was to the left
                    else
                    {
                        Debug.Log("Swiped left!");
                        direction = 'l';
                    }
                }
                // Check if the swipe was a vertical swipe (up or down)
                else
                {
                    // Check if the swipe was up
                    if (swipeDelta.y > 0)
                    {
                        Debug.Log("Swiped up!");
                        direction= 'u';
                    }
                    // Otherwise, the swipe was down
                    else
                    {
                        Debug.Log("Swiped down!");
                        direction= 'd';

                    }
                }
            }
        }
        return direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            rb.velocity = Vector3.zero;
        }
        if(other.gameObject.CompareTag("Spikes"))
        {
            Debug.Log("Game Over");
        }
    }
}
