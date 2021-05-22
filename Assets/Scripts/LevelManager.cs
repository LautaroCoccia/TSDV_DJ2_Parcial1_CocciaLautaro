using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] enum GameStates
    {
        Play,
        Pause,
        Win,
        Lose
    }
    GameStates actualState;
    // Start is called before the first frame update
    void Start()
    {
        actualState = GameStates.Play;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
