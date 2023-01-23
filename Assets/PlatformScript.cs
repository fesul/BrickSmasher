using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
	public float speed;

	public float distance;


	public float platformSize;

	float cameraSize;
	float cameraRatio;

	public PlatformVisual visual;

	void Start()
	{

	}

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

		visual.SetSize(platformSize);

		bool isLeftKeyPressed = Input.GetKey(KeyCode.LeftArrow);
		bool isRightKeyPressed = Input.GetKey(KeyCode.RightArrow);

		distance += isLeftKeyPressed ? -speed * Time.deltaTime : 0.0f;
		distance += isRightKeyPressed ? speed * Time.deltaTime : 0.0f;

		distance = Mathf.Clamp(distance, GameData.LeftBound + platformSize * 0.5f, GameData.RightBound - platformSize * 0.5f);

		transform.position = new Vector3(distance, 0.0f, 0.0f);

	}
}
