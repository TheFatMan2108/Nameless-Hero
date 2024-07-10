using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{
   public static CameraShakeManager instance { get; private set; }
    [SerializeField] private float range = 1f;
    private CinemachineImpulseListener impulseListener;
    private CinemachineImpulseDefinition impulseDefinition;
    private void Awake()
    {
        impulseListener = GetComponent<CinemachineImpulseListener>();
        if (instance == null)instance = this;
        else Destroy(gameObject);
    }

    public void CameraShake(CinemachineImpulseSource source)
    {
        source.GenerateImpulseWithForce(range);
    }
    public void ScreenShakeFromProfile(ScreenShakeProfile profile, CinemachineImpulseSource source)
    {
        // set up
        SetUpScreenSetting(profile,source);
        // screen shake
        source.GenerateImpulseWithForce(profile.impactForce);
    }

    private void SetUpScreenSetting(ScreenShakeProfile profile, CinemachineImpulseSource source)
    {
        impulseDefinition = source.m_ImpulseDefinition;
        impulseDefinition.m_ImpulseDuration = profile.impactTime;
        source.m_DefaultVelocity = profile.defaultVelocity;
        impulseDefinition.m_CustomImpulseShape = profile.impulseCurve;

        impulseListener.m_ReactionSettings.m_AmplitudeGain = profile.listernerAmplitude;
        impulseListener.m_ReactionSettings.m_FrequencyGain = profile.listernerFrequency;
        impulseListener.m_ReactionSettings.m_Duration = profile.listernerDuration;
    }
}
