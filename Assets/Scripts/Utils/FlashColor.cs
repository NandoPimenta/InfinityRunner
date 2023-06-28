using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenders;
    public Color color = Color.red;
    public float durationFlash = .1f;

    private Tween _currentTween;

    private void OnValidate()
    {
        spriteRenders = new List<SpriteRenderer>();
        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenders.Add(child);
        }
    }


       public void Flash()
    {
        if(_currentTween != null)
        {
            _currentTween.Kill();
            spriteRenders.ForEach(i => i.color = Color.white);
        }
        foreach(var s in spriteRenders)
        {
            _currentTween = s.DOColor(color,durationFlash).SetLoops(2,LoopType.Yoyo);
        }
    } 

}
