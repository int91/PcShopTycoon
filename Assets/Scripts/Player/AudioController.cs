using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public string audioName;
    [Header("Audio Stuff")]
    public AudioSource audioSrc;
    public AudioClip audioClp;
    public string soundPath;

    private void Awake() {
        audioSrc = gameObject.AddComponent<AudioSource>();
        soundPath = "file://" + Application.streamingAssetsPath + "/Sound/";
        StartCoroutine(LoadMusic());
    }

    private IEnumerator LoadMusic(){
        WWW request = GetAudioFromFile(soundPath, audioName);
        yield return request;

        audioClp = request.GetAudioClip();
        audioClp.name = audioName;
    }

    private void playaudio(){
        audioSrc.clip = audioClp;
        audioSrc.Play();
        audioSrc.loop = true;
        audioSrc.dopplerLevel = 0;
        audioSrc.volume = 0.5f;
    }

    private WWW GetAudioFromFile(string path, string filename){
        string audioToLoad = string.Format(path + "{0}", filename);
        WWW request = new WWW(audioToLoad);
        return request;
    }

}
