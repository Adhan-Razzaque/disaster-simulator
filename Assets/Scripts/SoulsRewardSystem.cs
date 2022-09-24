using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsRewardSystem : MonoBehaviour
{
    public static SoulsRewardSystem Instance { get; private set; }
    
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
    int CalculateReward(int height, int impactForce, int duration)
    {
        // TODO: Ben fill out a reward calculation system
        return 0;
    }
}
