using System;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationBox : MonoBehaviour
{
    public Button yes;
    public Button no;

    public event Action OnConfirmation;
    public event Action OnCancelled;

    public bool addSound;
    public AudioSource audiosource;
    public AudioClip onClickSound;
    
    public void Setup()
    {
        
    }

    void Start()
    {
        
    }
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnClickSound();
            Confirm();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickSound();
            Deny();
        }
    }

    public void Confirm()
    {
        OnConfirmation?.Invoke();
        Destroy(gameObject);
    }

    public void Deny()
    {
        OnCancelled?.Invoke();
        Destroy(gameObject);
    }
    
    public void OnClickSound()
    {
        if (addSound)
        {
            audiosource.clip = onClickSound;
            audiosource.Play();
        }
    }
    
}