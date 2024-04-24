using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    void OnMouseDown()
    {
        visualCue.SetActive(true);
    }
}
