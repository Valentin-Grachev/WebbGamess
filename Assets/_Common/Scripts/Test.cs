using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Anim_Scale anim;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            anim.Open();
        if (Input.GetMouseButtonDown(0))
            anim.Close();
    }
}
