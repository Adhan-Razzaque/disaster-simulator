using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;

public class GameManager : MonoBehaviour
{
    public AudioManager AudioManagerComponent;
    
    [SerializeField]
    private int disasterHeight;
    
    [SerializeField]
    private int disasterImpactForce;
    
    [SerializeField]
    private int disasterDurationInHours;

    private int _souls;

    private int _totalUpgrades = 0;

    public int Souls
    {
        get => _souls;

        private set
        {
            _souls = value;
            EventManager.TriggerEvent("SoulsChanged");
        }
    }

    public static GameManager Instance { get; private set; }

    struct Upgrade
    {
        public int Price;
        public bool Purchased;
        public int Value;

        public Upgrade(int price, bool purchased, int value)
        {
            Price = price;
            Purchased = purchased;
            Value = value;
        }
    }

    private Dictionary<String, Upgrade> _upgradesDictionary;

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
        Souls = 1;
        _upgradesDictionary = new Dictionary<string, Upgrade>
        {
            // Tier 1
            {"Height 1", new Upgrade(10, false, 5)},
            {"Force 1", new Upgrade(10, false, 5)},
            {"Duration 1", new Upgrade(1, false, 5)},
            // Tier 2
            {"Height 2", new Upgrade(1000, false, 25)},
            {"Force 2", new Upgrade(1000, false, 25)},
            {"Duration 2", new Upgrade(1000, false, 25)},
            // Tier 3
            {"Height 3", new Upgrade(100000, false, 100)},
            {"Force 3", new Upgrade(100000, false, 100)},
            {"Duration 3", new Upgrade(100000, false, 100)}
        };
        
        InvokeRepeating(nameof(RewardSouls), 5, 5);
        
        AudioManagerComponent.Play("Test");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RewardSouls()
    {
        int souls = SoulsRewardSystem.Instance.CalculateReward(disasterHeight, disasterImpactForce,
            disasterDurationInHours);

        Souls += souls;
    }

    private void CalculateImprovement(string upgradeName, int value)
    {
        if (upgradeName.Contains("Height"))
        {
            disasterHeight += value;
        }

        if (upgradeName.Contains("Force"))
        {
            disasterImpactForce += value;
        }

        if (upgradeName.Contains("Duration"))
        {
            disasterDurationInHours += value;
        }

        else
        {
            Debug.Log("Invalid Improvement Name");
        }
    }

    public bool PurchaseUpgrade(string upgradeName)
    {
        Upgrade upgrade;
        
        if (_upgradesDictionary.TryGetValue (upgradeName, out upgrade))
        {
            if (upgrade.Purchased)
            {
                return true;
            }
            
            if (upgrade.Price > Souls)
            {
                return false;
            }

            CalculateImprovement(upgradeName, upgrade.Value);
            Souls -= upgrade.Price;

            ++_totalUpgrades;
            if (_totalUpgrades == 9)
            {
                Debug.Log("Bought all upgrades");
            }

            return true;
        }
        
        return false;
    }
}
