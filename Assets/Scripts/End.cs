using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.Play("HeyGuysImHome");  // 7 seconds
        Invoke(nameof(PlayYesGod), 7f); // 2 seconds
        Invoke(nameof(PlayWatchTheDogs), 9f); // 6.5 seconds
        Invoke(nameof(PlayWasHeNot), 15.5f); // 4 seconds
        Invoke(nameof(PlayGoingToHell), 20f); // 4 seconds
    }
    
    public void PlayYesGod()
    {
        AudioManager.Instance.Play("YesGod");
    }
    
    public void PlayWatchTheDogs()
    {
        AudioManager.Instance.Play("WatchTheDogs");
    }

    public void PlayWasHeNot()
    {
        AudioManager.Instance.Play("WasHeNot");
    }

    public void PlayGoingToHell()
    {
        AudioManager.Instance.Play("GoingToHell");
    }
}
