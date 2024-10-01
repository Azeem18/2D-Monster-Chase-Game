using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX,maxX;

    // Start is called before the first frame update
    void Start()
    { 
        //It will get the transform property of object whose tag is Player
        player = GameObject.FindWithTag("Player").transform;
    }

    // LateUpdate is called When every calculation in update functions of all scripts has been executed so
    // that no glittering is performed by character
    void LateUpdate()
    {
        //This if statement is used prevent null refrence error when player gets destroyed by enemy 
        if(!player)
            return;
            
        tempPos = transform.position;
        tempPos.x = player.position.x;

        //setting max and min positions upto which camera follows character
        if(tempPos.x<minX)
            tempPos.x=minX;
        if(tempPos.x>maxX)
            tempPos.x=maxX;
        transform.position = tempPos;
    }
}
