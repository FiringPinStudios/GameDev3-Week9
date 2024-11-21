using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.DesignPattern
{
    [CreateAssetMenu(fileName = "Pool", menuName = "Scriptable Objects/Pool")]
    public class Pool_Data : ScriptableObject
    {
        public List<GameObject> pooledObjectContainer = new();

        public int poolAmount = 40;

        public GameObject poolItem;

        public void ResetThePool()
        {
            pooledObjectContainer.Clear();
        }
    }
}
