using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public void Awake()
    {
        UnityEngine.Application.targetFrameRate = 60;
    }
}
