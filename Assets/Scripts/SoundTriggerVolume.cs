using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerVolume : MonoBehaviour
{
    public string startSoundName = "";
    public string stopSoundName = "";
    public bool triggerOnce = true;

    private bool _triggered = false;
    
    public void OnTriggerEnter(Collider otherCollider)
    {
        if (triggerOnce && _triggered)
        {
            return;
        }

        _triggered = true;
        
        if (startSoundName != "")
        {
            AudioManager.Instance.Play(startSoundName);
        }
        
        if (stopSoundName != "")
        {
            AudioManager.Instance.Stop(startSoundName);
        }
    }
}
