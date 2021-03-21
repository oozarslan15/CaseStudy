using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundHandler : MonoBehaviour
{
    private AudioSource[] sounds;
    private AudioSource acc_low;
    private AudioSource acc_med;
    private AudioSource acc_high;
    private AudioSource dec_low;
    private AudioSource dec_med;
    private AudioSource dec_high;
    private AudioSource idle;

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        acc_low = sounds[0];
        acc_med = sounds[1];
        acc_high = sounds[2];
        dec_low = sounds[3];
        dec_med = sounds[4];
        dec_high = sounds[5];
        idle = sounds[6];
    }

    public void play_idle()
    {
        sounds[1].Stop();
        sounds[2].Stop();
        sounds[3].Stop();
        sounds[4].Stop();
        sounds[5].Stop();
        sounds[0].Stop();
        idle.PlayOneShot(idle.clip);
    }
    public void play_accLow()
    {
        sounds[1].Stop();
        sounds[2].Stop();
        sounds[3].Stop();
        sounds[4].Stop();
        sounds[5].Stop();
        sounds[6].Stop();
        acc_low.PlayOneShot(acc_low.clip);
    }
    public void play_accMed()
    {
        sounds[0].Stop();
        sounds[2].Stop();
        sounds[3].Stop();
        sounds[4].Stop();
        sounds[5].Stop();
        sounds[6].Stop();
        acc_med.PlayOneShot(acc_med.clip);
    }
    public void play_accHigh()
    {
        sounds[0].Stop();
        sounds[1].Stop();
        sounds[3].Stop();
        sounds[4].Stop();
        sounds[5].Stop();
        sounds[6].Stop();
        acc_high.PlayOneShot(acc_high.clip);
    }
    public void play_decLow()
    {
        sounds[0].Stop();
        sounds[1].Stop();
        sounds[2].Stop();
        sounds[4].Stop();
        sounds[5].Stop();
        sounds[6].Stop();
        dec_low.PlayOneShot(dec_low.clip);
    }
    public void play_decMed()
    {
        sounds[0].Stop();
        sounds[1].Stop();
        sounds[2].Stop();
        sounds[3].Stop();
        sounds[5].Stop();
        sounds[6].Stop();
        dec_med.PlayOneShot(dec_med.clip);
    }
    public void play_decHigh()
    {
        sounds[0].Stop();
        sounds[1].Stop();
        sounds[2].Stop();
        sounds[3].Stop();
        sounds[4].Stop();
        sounds[6].Stop();
        dec_high.PlayOneShot(dec_high.clip);
        
    }
}
