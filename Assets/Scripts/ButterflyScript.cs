using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ButterflyScript : SwatterScript
{
    public GameObject disappearEffectPrefab; 

    void Start()
    {
        base.Start();
        speed = 8f; 
    }

    void Update()
    {
        base.Update();
    }

    void OnDestroy()
    {
        PlayDisappearEffect(transform.position);
    }

    public void PlayDisappearEffect(Vector3 position)
    {
        GameObject effect = Instantiate(disappearEffectPrefab, position, Quaternion.identity);
        Destroy(effect, 1f); 
    }
}



