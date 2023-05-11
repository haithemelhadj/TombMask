using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public PlayerScript playerScript;
    public Transform player;
    public Vector3 offset;
    private Vector3 destination;
    public float speed;
    public float minDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        destination = new Vector3(player.position.x, offset.y, player.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, destination);
        if (  distance > minDistance )
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed);
        }
        
    }
}
