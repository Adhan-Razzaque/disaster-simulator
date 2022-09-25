using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _guiText;
    private const string _guiStub = "Souls: ";
    
    // Start is called before the first frame update
    void Start()
    {
        EventManager.StartListening("SoulsChanged", UpdateGUI);
    }

    void UpdateGUI()
    {
        int souls = GameManager.Instance.Souls;

        _guiText.text = _guiStub + souls;
    }
}
