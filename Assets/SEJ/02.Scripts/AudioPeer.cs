using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    AudioSource audio;
    public static float[] samples = new float[512];
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();

    }

    private void GetSpectrumAudioSource()
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
    //void MakeFrequencyBands()
    //{
    //    int count = 0;
    //    for(int i =0; i< 9; i++)
    //    {
    //        float average = 0;
    //        int sampleCount = (int)Mathf.Pow(2, i) * 2;

    //        if( i == 8)
    //        {
    //            sampleCount += 2;
    //        }
    //        for(int j =0; j<sampleCount; j++)
    //        {
    //            average += samples[count] * (count + 1);
    //            count++;
    //        }

    //        average /= count;
    //        freqBand[i] = average * 10;


    //    }
    //}


}
