using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New profile",menuName ="Data/Camera Shake Profile")]
public class ScreenShakeProfile : ScriptableObject
{
    [Header("Impulse Source Setting")]
    public float impactTime = 0.2f;
    public float impactForce = 1f;
    public Vector3 defaultVelocity = Vector3.down;
    public AnimationCurve impulseCurve;

    [Header("Impulse listener setting")]
    public float listernerAmplitude = 1f;
    public float listernerFrequency = 1f;
    public float listernerDuration = 1f;
}
