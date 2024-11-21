using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.DesignPattern
{
    public class ObjectPoolingPattern : Singleton<ObjectPoolingPattern>
    {
        [SerializeField] Pool_Data bulletPool;
        [SerializeField] Pool_Data muzzleFlashPool;

        public enum TypeOfPool
        {
            BulletPool,
            MuzzleFlash
        }
        // Start is called before the first frame update
        void Start()
        {
            FillThePool(bulletPool);
            FillThePool(muzzleFlashPool);
        }

        private void FillThePool (Pool_Data poolData)
        {
            poolData.ResetThePool();

            for (int i = 0; i < poolData.poolAmount; i++)
            {
                GameObject thingToAddToThePool = Instantiate(poolData.poolItem);
                thingToAddToThePool.transform.parent = transform;
                thingToAddToThePool.SetActive(false);
                poolData.pooledObjectContainer.Add(thingToAddToThePool);
            }
        }

        public GameObject GetPoolItem (TypeOfPool poolToUse)
        {
            Pool_Data pool = ScriptableObject.CreateInstance<Pool_Data>();

            switch (poolToUse)
            {
                case TypeOfPool.BulletPool:
                    pool = bulletPool;
                    break;
                case TypeOfPool.MuzzleFlash:
                    pool = muzzleFlashPool;
                    break;
            }

            for (int i = 0; i < pool.pooledObjectContainer.Count; i++)
            {
                if(!pool.pooledObjectContainer[i].activeInHierarchy)
                {
                    pool.pooledObjectContainer[i].SetActive(true);

                    return pool.pooledObjectContainer[i];
                }
            }

            Debug.LogWarning("No Availenle Items Found, Pool Too Small");

            return null;
        }
    }
}
