using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableBase : MonoBehaviour
{
    private bool IsCollected = false; 

    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float timeToHide = 2.0f;
    public GameObject graphicItem;
    
    
    [Header("Sounds")] public AudioSource audio;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(compareTag))
        {
            if (!IsCollected)
            {
                IsCollected = true;
                Collect();
            }
        }
    }



    protected virtual void Collect() {
        if(graphicItem != null)graphicItem.SetActive(false);
        Invoke(nameof(HideObject),timeToHide);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
    protected virtual void OnCollect()
    {
        if (particleSystem != null)particleSystem.Play();
        if(audio != null) audio.Play();
        
       
    }
    
    

}
