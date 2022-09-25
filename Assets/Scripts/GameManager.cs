using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int disasterHeight;
    
    [SerializeField]
    private int disasterImpactForce;
    
    [SerializeField]
    private int disasterDurationInHours;

    public int Souls { get; private set; }
    
    public static GameManager Instance { get; private set; }

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

    
    // Start is called before the first frame update
    void Start()
    {
        Souls = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddSouls(int soulsAdded)
    {
        Souls += soulsAdded;
        EventManager.TriggerEvent("SoulsChanged");
    }

    bool purchaseUpgrade(string upgradeName)
    {
        return false;
    }
}
