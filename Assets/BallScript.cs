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

	public Brick[] bricks;

	public PlatformScript platform;

	void Start()
	{
		position = transform.position;

		Utility ut = new Utility();

		bricks   = GameObject.FindObjectsOfType<Brick>();
		platform = GameObject.FindObjectOfType<PlatformScript>();
	}

	// Update is called once per frame
	void Update()
	{
		transform.localScale = Vector3.one * radius * 2.0f;

		if (isAlive)
			position += direction * speed * Time.deltaTime;

		isAlive = position.y - radius > 0.0f;

		bool collidedWithPlatofrm = Utility.CollisionWithRect(position, platform.transform.position, platform.platformWidth, platform.platformHeight, radius);

		if (collidedWithPlatofrm) 
		{
			position.y = platform.transform.position.y + platform.platformHeight * 0.5f + radius;
			direction = Vector2.Reflect(direction, Vector2.up);
		}

		for(int i = 0 ; i < bricks.Length; i++)
		{
			Brick brick = bricks[i];

			bool isColliding = Utility.CollisionWithRect(position, brick.Position, brick.width, brick.height, radius);

			if(isColliding)
			{
				//REFLECT
				Reflect(ref position, ref direction, brick.Position, brick.width, brick.height, radius);
			}
		}

		if (!isAlive)
		{
			Debug.Log("DEAD");
		}

		ReflectDirectionAfterTouchingBounds();
		transform.position = position;
	}


	void Reflect(ref Vector2 position,  ref Vector2 direction, Vector2 colliderPos, float width, float height, float radius)
	{

		float leftSide 	= colliderPos.x - width  * 0.5f;
		float rightSide = colliderPos.x + width  * 0.5f;
		float topSide 	= colliderPos.y + height * 0.5f;
		float botSide 	= colliderPos.y - height * 0.5f;

		if(position.x > leftSide && position.x < rightSide)
		{
			if(position.y > colliderPos.y)
			{
				//TOP SIDE
				position.y = topSide + radius;
				direction = Vector2.Reflect(direction, Vector2.up);
			}
			else
			{
				//BOT SIDE
				position.y = botSide - radius;
				direction = Vector2.Reflect(direction, Vector2.down);
			}
		}

		 if(position.y > botSide && position.y < topSide)
		{
			if(position.x > colliderPos.x)
			{
				//RIGHT SIDE
				position.x = rightSide + radius;
				direction = Vector2.Reflect(direction, Vector2.right);
			}
			else
			{
				//LEFT SIDE
				position.x = leftSide - radius;
				direction = Vector2.Reflect(direction, Vector2.left);
			}
		}
	}

	void ReflectDirectionAfterTouchingBounds()
	{
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
	}

}
