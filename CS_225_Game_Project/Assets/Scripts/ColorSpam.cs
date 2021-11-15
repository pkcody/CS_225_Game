using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpam : MonoBehaviour
{
    PlayerController player;

    List<Color> colorList = new List<Color>()
    {
        Color.red,
        Color.cyan,
        Color.black,
        Color.yellow,
        Color.green
    };

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(RunColor());
        }
    }

    public IEnumerator RunColor()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);

        for (int x = 0; x< colorList.Count; x++) // for loop
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
            player.mat.color = colorList[x];
            Debug.Log("color change");
            yield return wait;
        }
        player.SetColor();
    }

}
