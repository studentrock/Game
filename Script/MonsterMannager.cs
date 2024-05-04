using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MonsterMannager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movespeed=1f;
    [SerializeField] private PlayerManager playerManager;

private void FixedUpdate()
{
    var PlayerPosition = playerManager.position;
    var position = (Vector2)transform.position;
    var direction = PlayerPosition - position;
    direction.Normalize();
    var targetPostion = position + direction;
    rb.DOMove(targetPostion,movespeed).SetSpeedBased();
}

}
