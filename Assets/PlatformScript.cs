using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
	public float speed;

	public float distance;


	public float platformWidth;
	public float platformHeight;

	float cameraSize;
	float cameraRatio;

	public PlatformVisual visual;

	// Update is called once per frame
	void Update()
	{

		cameraSize = Camera.main.orthographicSize;
		cameraRatio = Camera.main.aspect;

		GameData.TopBound		=  cameraSize + Camera.main.transform.position.y;
		GameData.BottomBound	= -cameraSize + Camera.main.transform.position.y;
		GameData.LeftBound		= -cameraSize * cameraRatio;
		GameData.RightBound		=  cameraSize * cameraRatio;

		//-----------------------------------------------------------

		visual.SetSize(platformWidth);

		bool isLeftKeyPressed = Input.GetKey(KeyCode.LeftArrow);
		bool isRightKeyPressed = Input.GetKey(KeyCode.RightArrow);

		distance += isLeftKeyPressed ? -speed * Time.deltaTime : 0.0f;
		distance += isRightKeyPressed ? speed * Time.deltaTime : 0.0f;

		distance = Mathf.Clamp(distance, GameData.LeftBound + platformWidth * 0.5f, GameData.RightBound - platformWidth * 0.5f);

		transform.position = new Vector3(distance, platformHeight * 0.5f, 0.0f);

	}
}
