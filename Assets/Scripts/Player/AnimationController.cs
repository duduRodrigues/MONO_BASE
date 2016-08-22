using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    public Animator anime;
    private Player _player;
    private Rigidbody2D _rbPlayer;
    //private bool walk;
    //private bool isJumping;
    private float velocidadeY;
    //private bool correndo;
    //private bool run;

    // Use this for initialization
    void Start()
    {

        _player = FindObjectOfType<Player>();
        _rbPlayer = _player.GetComponent<Rigidbody2D>();
        //correndo = _player.isRunning();

    }

    // Update is called once per frame
    void Update()
    {

        //isJumping = player.isJumping();
        //correndo = player.isRunning();

        //if (player.getMovimentoX() != 0 && !correndo)
        //{
        //    walk = true;
        //    run = false;
        //}
        //else if (player.getMovimentoX() != 0 && correndo)
        //{
        //    walk = false;
        //    run = true;
        //}
        //else
        //{
        //    walk = false;
        //    run = false;
        //}

        //velocidadeY = _player.GetComponent<Rigidbody2D>().velocity.y;


        if (!_player.IsDead)
        {

            anime.SetBool("walk", _player.IsWalking);
            anime.SetBool("running", _player.IsRunning);
            anime.SetBool("isJumping", _player.IsJumping);
            anime.SetFloat("speedY", _rbPlayer.velocity.y);
        }

    }
}
