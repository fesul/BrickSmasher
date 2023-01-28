using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Utility 
{
    public static bool CollisionWithRect(Vector3 position,  Vector3 colliderPosition, float width, float height, float radius) 
	{

		float halfWidth = width * 0.5f;
		float halfHeight = height * 0.5f;

		bool horizontalCheck	= position.x + radius > colliderPosition.x - halfWidth  && position.x - radius < colliderPosition.x + halfWidth;
		bool verticalCheck		= position.y + radius > colliderPosition.y - halfHeight && position.y - radius < colliderPosition.y + halfHeight;

		return horizontalCheck && verticalCheck;
	}
}
