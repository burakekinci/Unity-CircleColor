using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform Player;
    public float smooth;
    private Vector2 velocity;
    
    
    void FixedUpdate(){
        float posY = Mathf.SmoothDamp(transform.position.y, Player.position.y+3, ref velocity.y, smooth);
        transform.position = new Vector3(0, posY, transform.position.z);
    }
}
