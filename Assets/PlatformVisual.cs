using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVisual : MonoBehaviour
{

    public Transform leftCircle;
    public Transform rightCircle;
    public Transform midSquare;

    public void SetSize(float size)
    {
        midSquare.localScale = new Vector3(size - 0.2f, 0.2f, 1.0f);
        leftCircle.localPosition  = new Vector3(size * -0.5f + 0.1f, 0.0f,0.0f);
        rightCircle.localPosition = new Vector3(size * 0.5f - 0.1f, 0.0f,0.0f);
    }

}
