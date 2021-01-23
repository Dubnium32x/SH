using System;
using System.IO;
using UnityEngine;

public class RegularMusic : MonoBehaviour
{
    public AudioSource SecondaryMusic;
    bool StopGo;
    AudioClip loadedMod;
    public void Start()
    {
    }
    void Update()
    {
        float[] f = ConvertByteToFloat(File.ReadAllBytes(Application.dataPath + "Mods/Level" + SDR.SDVint(SDR.SDVint("CurrentFileLoaded: ").ToString() + "Level: ").ToString() + ".wav"));
        if (SDR.DDVER("mod support") && loadedMod != null)
        {
            loadedMod = AudioClip.Create("LevelMusic", f.Length, 1, 44100, false);
            loadedMod.SetData(f, 0);
            GetComponent<AudioSource>().clip = loadedMod;
        }
        if (SecondaryMusic.isPlaying)
        {
            FadeOut(1.6f);
            StopGo = true;
        }
        else
        {
            FadeIn(1.6f, 1);
            StopGo = false;
        }
    }
    void FadeOut(float a)
    {
        if (StopGo == true)
        GetComponent<AudioSource>().volume -= a * Time.deltaTime;
        
    }
    void FadeIn(float a, float whenStop)
    {
        if(GetComponent<AudioSource>().volume <= whenStop && StopGo == false)
            GetComponent<AudioSource>().volume += a * Time.deltaTime;
    }
    private float[] ConvertByteToFloat(byte[] array)
    {
        float[] floatArr = new float[array.Length / 4];
        for (int i = 0; i < floatArr.Length; i++)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(array, i * 4, 4);
            floatArr[i] = BitConverter.ToSingle(array, i * 4) / 0x80000000;
        }
        return floatArr;
    }
}
