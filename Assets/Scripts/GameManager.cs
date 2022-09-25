using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int disasterHeight;
    
    [SerializeField]
    private int disasterImpactForce;
    
    [SerializeField]
    private int disasterDurationInHours;

    private int _souls;

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

        public Upgrade(int price, bool purchased)
        {
            Price = price;
            Purchased = purchased;
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
        Souls = 0;
        _upgradesDictionary = new Dictionary<string, Upgrade>();
        
        // Tier 1
        _upgradesDictionary.Add("Height 1", new Upgrade(10, false));
        _upgradesDictionary.Add("Force 1", new Upgrade(10, false));
        _upgradesDictionary.Add("Duration 1", new Upgrade(10, false));
        
        // Tier 2
        _upgradesDictionary.Add("Height 2", new Upgrade(100, false));
        _upgradesDictionary.Add("Force 2", new Upgrade(100, false));
        _upgradesDictionary.Add("Duration 2", new Upgrade(100, false));
        
        // Tier 3
        _upgradesDictionary.Add("Height 3", new Upgrade(1000, false));
        _upgradesDictionary.Add("Force 3", new Upgrade(1000, false));
        _upgradesDictionary.Add("Duration 3", new Upgrade(1000, false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddSouls(int soulsAdded)
    {
        if (soulsAdded == 0)
        {
            return;
        }
        
        Souls += soulsAdded;
    }

    bool purchaseUpgrade(string upgradeName)
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

            Souls -= upgrade.Price;
            return true;
        }
        
        return false;
    }
}
