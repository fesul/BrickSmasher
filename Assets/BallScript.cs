using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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

	public float radius;

	public bool isAlive;


	public PlatformScript platform;

	void Start()
	{
		position = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.localScale = Vector3.one * radius * 2.0f;

		if (isAlive)
			position += direction * speed * Time.deltaTime;

		isAlive = position.y - radius > 0.0f;

		bool collidedWithPlatofrm = CollidedWithPlatform(position);

		if (collidedWithPlatofrm) 
		{
			Debug.Log("collidedWithPlatofrm");

			position.y = platform.transform.position.y + platform.platformHeight * 0.5f + radius;
			direction = Vector2.Reflect(direction, Vector2.up);
		}

		if (!isAlive)
		{
			Debug.Log("DEAD");
		}

		if (position.x < GameData.LeftBound + radius)
		{
			position.x = GameData.LeftBound + radius;
			direction = Vector2.Reflect(direction, Vector2.right);
		}

		else if (position.x > GameData.RightBound - radius)
		{
			position.x = GameData.RightBound - radius;
			direction = Vector2.Reflect(direction, Vector2.left);
		}

		else if (position.y > GameData.TopBound - radius)
		{
			position.y = GameData.TopBound - radius;
			direction = Vector2.Reflect(direction, Vector2.down);
		}

		else if (position.y < GameData.BottomBound + radius)
		{
			position.y = GameData.BottomBound + radius;
			direction = Vector2.Reflect(direction, Vector2.up);
		}

		transform.position = position;
	}

	bool CollidedWithPlatform(Vector3 position) 
	{
		Vector3 platformPosition = platform.transform.position;

		float halfWidth = platform.platformWidth * 0.5f;
		float halfHeight = platform.platformHeight * 0.5f;

		bool horizontalCheck	= position.x + radius > platformPosition.x - halfWidth  && position.x - radius < platformPosition.x + halfWidth;
		bool verticalCheck		= position.y + radius > platformPosition.y - halfHeight && position.y - radius < platformPosition.y + halfHeight;

		return horizontalCheck && verticalCheck;
	}
}
