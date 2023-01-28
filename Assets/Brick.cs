using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    //STEP 1 : Check if ball touches the brick - X
    //STEP 2 : Update Score
    //STEP 3 : Bounce / Reflect Ball
    //STEP 4 : Destroy Brick

    public BallScript ball;
    public float width;
    public float height;

    public Vector3 Position => transform.position;

    void Update()
    {
        //Set width and height of Brick transform.
        transform.localScale = new Vector3(width, height, 1.0f);
    }
}
