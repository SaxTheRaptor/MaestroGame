using Assets.Scripts.CombatSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeIndicator : MonoBehaviour
{
   
    public NoteCombatSystem noteCombatSystem;
    private float indicatorFlashingTime;
    private Vector3 startingIndicatorScale;
    private bool indicatorFlashing = false;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startingIndicatorScale = this.transform.localScale;
        noteCombatSystem.NoteHit += StartFlashingIndicator;
        this.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        FlashIndicator();
    }

    void FlashIndicator()
    {
        if (indicatorFlashingTime > 2)
        {
            DisableIndicator();
        }
        if (indicatorFlashing)
        {
            indicatorFlashingTime += Time.deltaTime;
            this.transform.localScale = Vector3.Scale(startingIndicatorScale, new Vector3((Mathf.Sin(indicatorFlashingTime) + 3) / 2, (Mathf.Sin(indicatorFlashingTime) + 3) / 2, 1));
        }
    }

    private void StartFlashingIndicator(object sender, System.EventArgs args)
    {
        NoteHitEventArgs noteArgs = (NoteHitEventArgs)args;
        indicatorFlashingTime = 0;
        indicatorFlashing = true;
        spriteRenderer.sprite = noteArgs.Grade.spriteOnHit;
        this.gameObject.SetActive(true);

    }

    private void DisableIndicator()
    {

        indicatorFlashing = false;
        this.transform.localScale = startingIndicatorScale;
        this.gameObject.SetActive(false);
    }
}
