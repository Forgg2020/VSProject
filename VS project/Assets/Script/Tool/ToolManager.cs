using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ToolManager
{
    public class FindObj
    {
        public GameObject FindObjectbyTag(string tag)
        {
            return GameObject.FindGameObjectWithTag(tag);
        }
        public GameObject[] FindObjectsbyTag(string tag)
        {
            return GameObject.FindGameObjectsWithTag(tag);
        }
        public GameObject FindObjectbyName(string name)
        {
            return GameObject.Find(name);
        }
        //public GameObject FindObjectbyScriptClass(GameObject obj)
        //{
        //    return GameObject.Find(obj.GetComponent<MonoBehaviour>().GetType().IsSubclassOf(typeof(WeaponAbstructClass)));
        //}
        public void FindObjectScript<T>(string name, out T component) where T : Component
        {
            GameObject target = GameObject.Find(name);
            if (target != null)
            {
                component = target.GetComponent<T>();
            }
            else
            {
                Debug.LogError($"Can't find {name}");
                component = null;
            }
        }
    }

    public class colliderManager : MonoBehaviour
    {
        protected virtual string CollisionTag { get; } = "Player";

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(CollisionTag))
            {
                onCollisionPlayer(other);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(CollisionTag))
            {
                onCollisionExitPlayer(other);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(CollisionTag))
            {
                OnTriggerPlayer(other);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(CollisionTag))
            {
                OnTriggerExitPlayer(other);
            }
        }
        //************************************************************************//
        protected virtual void onCollisionPlayer(Collision2D other)
        {

        }
        protected virtual void OnTriggerPlayer(Collider2D other)
        {

        }

        protected virtual void onCollisionExitPlayer(Collision2D other)
        {

        }
        protected virtual void OnTriggerExitPlayer(Collider2D other)
        {

        }

    }

    public class TimeFunction
    {
        public void StopTime()
        {
            Time.timeScale = 0;
        }
        public void KeepTime()
        {
            Time.timeScale = 1;
        }
    }
}