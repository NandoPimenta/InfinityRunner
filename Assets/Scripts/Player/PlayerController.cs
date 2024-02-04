using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public Transform target;
    public float learpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndline = "EndLine";

    public GameObject startScreen;
    public GameObject endScreen;

    //powerUps
    //public string uiTextPowerUp;

    [Header("Coin Setup")]
    public GameObject coinCollect;


    //private
    private bool _canRun = false;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private bool _invencible;


    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();

    }

    void Update()
    {
        if (!_canRun) { return; }

        _pos = target.position;

        _pos.y = transform.position.y;
        _pos.z = transform.position.z;



        transform.position = Vector3.Lerp(transform.position, _pos, learpSpeed * Time.deltaTime);


        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);

        if (_pos.x < -4.86f || _pos.x > -0.25)
        {
            target.position = new Vector3(_pos.x < -4.86f ? -4.86f : -0.25f, target.position.y, target.position.z);
        }




    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == tagToCheckEndline)
        {
            _canRun = false;
            endScreen.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy && !_invencible)
        {
            _canRun = false;
            endScreen.SetActive(true);
        }
    }


    public void StartToRun()
    {
        _canRun = true;
        startScreen.SetActive(false);
    }



    #region Power Ups
    public void SetPowerUpText(string s)
    {
        //  uiTextPowerUp = s;
    }
    public void PowerUpSpeed(float f)
    {
        _currentSpeed += f;
    }
    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }
    public void SetInvencible(bool b)
    {
        _invencible = b;
    }
    public void SetHeight(float amount, float duration, float animationDuration, DG.Tweening.Ease ease) {
     
        transform.DOMoveY(_startPosition.y + amount,
            animationDuration).SetEase(ease)
            .OnComplete(()=> transform.DOMoveY(_startPosition.y, animationDuration).SetEase(ease)).SetEase(ease);
    }

     public void SetCoinCollect(float sizeAmount)
    {
        coinCollect.transform.localScale = Vector3.one * sizeAmount;

    }


    #endregion

}
