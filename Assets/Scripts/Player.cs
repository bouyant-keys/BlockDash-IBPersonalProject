using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject _pauseMenu;
    SceneLoader _sceneLoader;
    Rigidbody2D _rigidBody;
    BoxCollider2D _boxCollider;
    Animator _animator;
    ProgressManager _progressManager;

    [SerializeField] float _playerSpeed = 1000;
    [SerializeField] float _playerVelocity;
    [SerializeField] float _horizontalDir;
    [SerializeField] float _verticalDir;
    [SerializeField] Vector2 _lastDirMoved;
    [SerializeField] float _bufferDist = 0.05f;
    [SerializeField] bool _playerInMotion = false;

    // Use this for initialization
    void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
        _progressManager = GameObject.FindGameObjectWithTag("ProgressManager").GetComponent<ProgressManager>();
        _pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");

        transform.position = GameObject.FindGameObjectWithTag("StartPortal").transform.position;
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate() {
        _playerVelocity = _rigidBody.velocity.magnitude;

        if (!_playerInMotion)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                _horizontalDir = Mathf.Sign(Input.GetAxis("Horizontal"));
                _rigidBody.velocity = new Vector2(_horizontalDir * (Time.deltaTime * _playerSpeed), 0f);

                _lastDirMoved = new Vector2(_horizontalDir, 0f);
                _playerInMotion = true;
            }
            else if (Input.GetAxis("Vertical") != 0)
            {
                _verticalDir = Mathf.Sign(Input.GetAxis("Vertical"));
                _rigidBody.velocity = new Vector2(0f, _verticalDir * (Time.deltaTime * _playerSpeed));

                _lastDirMoved = new Vector2(0f, _verticalDir);
                _playerInMotion = true;
            }
            else
            {
                _horizontalDir = 0f;
                _verticalDir = 0f;
            }
        }
        else
        {
            if (_playerVelocity == 0f)
            {
                AddBuffer(_lastDirMoved);
                _playerInMotion = false;
            }
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        }
    }

    private void AddBuffer(Vector2 _facingDir)
    {
        //Moves player slightly away from wall hit
        transform.position = new Vector2(transform.position.x + (_bufferDist * -_facingDir.x), transform.position.y + (_bufferDist * -_facingDir.y));
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        if (obj.tag.Equals("EndPortal"))
        {
            _animator.SetTrigger("exitTrigger");
        }
        else
        {
            _animator.SetTrigger("deathTrigger");
        }
    }

    public void Win()
    {
        _progressManager.UpdateProgress(_sceneLoader.GetCurrentLevelIndex());
        _sceneLoader.LoadNextLevel();
    }

    void Die()
    {
        Destroy(gameObject);
        _sceneLoader.LoadScene("03b GameOver");
    }
}
