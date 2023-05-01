using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioYB _audio;


    private void Start()
    {
        _audio.Play("music");
        _audio.loop = true;
    }


}
