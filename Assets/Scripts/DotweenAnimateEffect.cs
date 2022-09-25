using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DotweenAnimateEffect : MonoBehaviour
{
    public static DotweenAnimateEffect instance;
    [SerializeField] private CanvasGroup fadingUI;
    private void Awake()
    {
        instance = this;
    }

    public void AttackAnimation(GameObject gameObject1, GameObject gameObject2,bool player)
    {
        //change side depend on player or enemy
        int side;
        if (player)
        {
            side = 10;
        }
        else side =-10;
        var duration = 0.5f;
        gameObject1.transform.DOPunchPosition(
            punch: Vector3.right * side,
            duration: 0.5f,
            vibrato:0,
            elasticity:0
            ) ;
        gameObject2.transform.DOShakePosition(
            duration: 0.5f,
            strength: 5f,
            vibrato: 10
            ).SetDelay(duration*0.5f) ;

    }
    public void HandleDeadObject(GameObject gameObject)
    {
        gameObject.transform.DOMoveY(-20f, 1f, true);
    }

    public void HealAnimation(GameObject gameObject)
    {
        gameObject.transform.DOPunchScale(
            punch: Vector3.one* 10f,
            duration: 0.5f,
            vibrato: 0,
            elasticity: 0
            );
    }

}
