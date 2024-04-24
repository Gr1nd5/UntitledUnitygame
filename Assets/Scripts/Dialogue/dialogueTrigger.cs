using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool userClicked;

    private void Awake()
    {
        visualCue.SetActive(false);
        userClicked = false;
    }

    private void Update()
    {
        if (userClicked && !DialogueManager.GetInstiance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DialogueManager.GetInstiance().EnterDialogueMode(inkJSON);
            }

        }
        else
        {
            visualCue.SetActive(false);
        }

    }

    private void OnMouseDown()
    {
        userClicked = true;
    }
}
