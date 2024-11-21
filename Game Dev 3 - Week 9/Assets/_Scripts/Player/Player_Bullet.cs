using GameDevWithMarco.DesignPattern;
using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class Player_Bullet : MonoBehaviour
    {
        [SerializeField] GameObject flash;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //To get where specifically I have collided 
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Vector2 collisionPoint = contact.point;//Add a cool muzzleflash in collision
                float randomRange = Random.Range(05f, 1.5f);
                var flashObj = ObjectPoolingPattern.Instance.GetPoolItem(ObjectPoolingPattern.TypeOfPool.MuzzleFlash);
                flashObj.transform.localScale = new Vector3(randomRange, randomRange, randomRange);
                flashObj.transform.position = collisionPoint;
            }
            //Returns the game object to the available pool
            gameObject.SetActive(false);
        }
    }
}
