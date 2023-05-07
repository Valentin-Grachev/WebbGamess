using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private string musicName;
    [SerializeField] private AudioYB _audio;


    private void Start()
    {
        _audio.Play(musicName);
        _audio.loop = true;
    }


}
