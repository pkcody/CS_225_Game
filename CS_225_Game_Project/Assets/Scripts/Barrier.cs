using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private int damage;
    private int levelHardness;

    public GameManager _gm;

    public int barrierTotalDamge;

    public int getDamage()
    {
        return damage * levelHardness;
    }
    public void setDamage( int dam )
    {
        damage = dam;
    }
    public void setLevelHardness(int ld)
    {
        levelHardness = ld;
    }

    public static Barrier operator +(Barrier a, Barrier b) //operator overloading
    {
        Barrier barrier = new Barrier();
        barrier.damage = a.damage + b.damage;
        barrier.levelHardness = a.levelHardness + b.levelHardness;

        return barrier;
    }

    private void Awake()
    {
        _gm = GameObject.Find("_GameManager").GetComponent<GameManager>();

        Barrier Damage1 = new Barrier();
        Barrier Damage2 = new Barrier();
        Barrier Damage3 = new Barrier();

        int totalDamage = 0;

        Damage1.setDamage(4);
        Damage1.setLevelHardness(1);
        Damage2.setDamage(6);
        Damage2.setLevelHardness(2);

        Damage3 = Damage1 + Damage2;
        totalDamage = Damage3.getDamage();

        barrierTotalDamge = totalDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("damage taken " + barrierTotalDamge);
            _gm.health -= barrierTotalDamge;
        }
    }
}