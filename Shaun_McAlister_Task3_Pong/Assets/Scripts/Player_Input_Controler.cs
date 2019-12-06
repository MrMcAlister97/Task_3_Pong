using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNumber { One, Two }

public class Player_Input_Controler : MonoBehaviour
{
    //player's speed
    [SerializeField]
    private float _playerSpeed = 6;

    [SerializeField]
    private Vector2 _offset = new Vector2(1f, 1.5f);

    [SerializeField]
    private string _controlName;

    [SerializeField]
    private PlayerNumber _playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (_playerNumber == PlayerNumber.One)
        {
            transform.position = new Vector3(CameraBounds.BottomLeft.x + _offset.x, 0f, 0f);
        }
        else if (_playerNumber == PlayerNumber.Two)
        {
            transform.position = new Vector3(CameraBounds.TopRight.x - _offset.x, 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis(_controlName);

        // move by (0, 1, 0) x vertical input axis (-1 - 0 - 1) x speed x framerate (otherwise it goes hella fast)
        transform.Translate(Vector3.up * vert * _playerSpeed * Time.deltaTime);

        if (transform.position.y > CameraBounds.TopRight.y - _offset.y)
        {
            Vector3 pos = transform.position;
            pos.y = CameraBounds.TopRight.y - _offset.y;
            transform.position = pos;
        }

        if (transform.position.y < CameraBounds.BottomLeft.y + _offset.y)
        {
            Vector3 pos = transform.position;
            pos.y = CameraBounds.BottomLeft.y + _offset.y;
            transform.position = pos;
        }
    }
}
