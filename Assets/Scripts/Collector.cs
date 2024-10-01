using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to destroy enemeies which are going out of bounds 
public class Collector : MonoBehaviour
{
    //onTriigerEnter2d is built-in function which is used when we enable isTriger check in inspector panel
    // and it detects the collision of object by comparing the tag of other object
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Player")){
            Destroy(collision.gameObject);//Here the object which is colliding with this collector object will be destroyed
    }
    }
}
