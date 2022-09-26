using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoulsRewardSystem : MonoBehaviour
{
    public static SoulsRewardSystem Instance { get; private set; }

    [Range(0, 100)]
    public float heightScaler = 2f;
    
    [Range(0, 100)]
    public float impactForceScaler = 3f;
    
    [Range(0, 100)]
    public float durationScaler = 4f;
    
    
    void Awake()
    {
        // Makes this a singleton instance
        if (Instance != null && Instance != this)  // Instance is populated and is not already this
        {
            Destroy(this);
        }
        else  // Instance is not populated or is already this
        {
            Instance = this;
        }
        
        // Set me to Don't Destroy on Load when I start
        DontDestroyOnLoad(this);
    }

    // Calculate the reward given the parameters 
    //returns the number of souls
    public int CalculateReward(int height, int impactForce, int duration)
    {
        float randomDoubler = (Random.value % 1) + 1;

        return (int) Math.Ceiling(randomDoubler * (heightScaler * height + impactForceScaler * impactForce + durationScaler * duration));
    }
}
