using UnityEngine;
using System.Collections;

namespace SpatialPartitionPattern
{
    public class Enemy : Soldier
    {

        Vector3 currentTarget;
        Vector3 oldPos;
        float mapWidth;
        Grid grid;


        //Init enemy
        public Enemy(GameObject soldierObj, float mapWidth, Grid grid)
        {
            this.soldierTrans = soldierObj.transform;

            this.soldierMeshRenderer = soldierObj.GetComponent<MeshRenderer>();

            this.mapWidth = mapWidth;

            this.grid = grid;
            grid.Add(this);
            oldPos = soldierTrans.position;
            this.walkSpeed = 5f;

            GetNewTarget();
        }


        //Move the cube randomly across the map
        public override void Move()
        {
            soldierTrans.Translate(Vector3.forward * Time.deltaTime * walkSpeed);
            grid.Move(this, oldPos);
            oldPos = soldierTrans.position;


            if ((soldierTrans.position - currentTarget).magnitude < 1f)
            {
                GetNewTarget();
            }
        }


        //Give the enemy a new target to move towards and rotate towards that target
        void GetNewTarget()
        {
            currentTarget = new Vector3(Random.Range(0f, mapWidth), 0f, Random.Range(0f, mapWidth));
            soldierTrans.rotation = Quaternion.LookRotation(currentTarget - soldierTrans.position);
        }
    }
}