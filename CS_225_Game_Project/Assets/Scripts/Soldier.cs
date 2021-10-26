
using UnityEngine;
using System.Collections;

namespace SpatialPartitionPattern
{
    //The soldier base class for enemies and friendly
    public class Soldier
    {
        public MeshRenderer soldierMeshRenderer;
        public Transform soldierTrans;
        protected float walkSpeed;
        public Soldier previousSoldier;
        public Soldier nextSoldier;

        public virtual void Move()
        { }

        public virtual void Move(Soldier soldier)
        { }
    }
}