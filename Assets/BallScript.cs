using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update

    //Step 1 : Movement

    //Step 2 : Bounce

    //Step 3 : Death on ground

    //Step 4 : Destroy Bricks

    public float speed;

    
    public Vector2 direction;

    public Vector2 position;

    public Rigidbody2D rigidbody2D;

    void Start()
    {
      //  direction = Random.insideUnitCircle.normalized;
        position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        position += direction * speed * Time.deltaTime;

        if (position.x < GameData.LeftBound) 
        {
            Debug.Log("Left Bound");
            direction = Vector2.Reflect(direction, Vector2.right);
		}

		else if (position.x > GameData.RightBound)
		{
			Debug.Log("Left Right");

			direction = Vector2.Reflect(direction, Vector2.left);
		}

		else if (position.y > GameData.TopBound)
		{

			Debug.Log("Top Bound");

			direction = Vector2.Reflect(direction, Vector2.down);
		}

		else if (position.y < GameData.BottomBound)
		{

			Debug.Log("Top Bound");

			direction = Vector2.Reflect(direction, Vector2.up);
		}

		transform.position = position;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        Debug.Log("COllision happened! with " + collision.collider.name);
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("Trigger happened! with ");

	}
}
