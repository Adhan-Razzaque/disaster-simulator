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
    //returns the number of souls
    int CalculateReward(int height, int impactForce, int duration)
    {
        // TODO: Ben fill out a reward calculation system

        //Tiers based off how powerful Tsunami is for soul currency to be rewarded with
        if(height <= 20 && impactForce <= 20 && duration <= 20){ //tier 1
            
             System.out.println("You have been rewared with 20 souls");
            return 20;
        }
        else if(height <= 40  && impactForce <= 40 && duration <= 40 ){ //tier 2
            System.out.println("You have been rewared with 40 souls");
            return 40;
        }
        else if (height <=  60 && impactForce <= 60 && duration <= 60)//tier 3
        {
             System.out.println("You have been rewared with 60 souls");
            return 60;
        }
        else if (height <= 80  && impactForce <= 80 && duration <= 80 )//tier 4
        {

            System.out.println("You have been rewared with 80 souls");
            return 80;
            
        }
        else{ //tier 5 height, impactForce, and duration == 100
            System.out.println("You have been rewared with 100 souls");
            return 100;
           
        }

        
    }
}
