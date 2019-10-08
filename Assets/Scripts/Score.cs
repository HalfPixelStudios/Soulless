using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score:MonoBehaviour
{
    public GameObject player;
    private TextMeshPro text;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = player.GetComponent<PlayerHealth>();
        text = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        text.text = "Deaths: " + _playerHealth.deaths;

    }
}
