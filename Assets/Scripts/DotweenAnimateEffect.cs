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
        gameObject1.transform.DOPunchPosition(
            punch: Vector3.right * side,
            duration: 0.5f,
            vibrato:0,
            elasticity:0
            ) ;
        DamageRecieveAnimation(gameObject2);
    }
    public void DamageRecieveAnimation(GameObject gameObject)
    {
        gameObject.transform.DOShakePosition(
            duration: 0.5f,
            strength: 5f,
            vibrato: 10
            ).SetDelay(0.5f) ;
    }
    public void HandleDeadObject(GameObject gameObject)
    {
        gameObject.transform.DOMoveY(-20f, 1f, true);
    }

    public void SpecialSkillAnimation(GameObject gameObject)
    {
        gameObject.transform.DOPunchScale(
            punch: Vector3.one* 10f,
            duration: 0.5f,
            vibrato: 0,
            elasticity: 0
            );
    }

}
