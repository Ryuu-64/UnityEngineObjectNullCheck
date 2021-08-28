using System.Collections;
using UnityEngine;

namespace Script
{
    public class UniyEngineObjectNullCheck : MonoBehaviour
    {
        public GameObject go;

        private void Start() => StartCoroutine(NullCheckTest());

        private IEnumerator NullCheckTest()
        {
            WaitForSeconds waitTime = new WaitForSeconds(1);
            yield return waitTime;
            Debug.Log("go not set");
            Debug.Log($"Reference Equals null: {ReferenceEquals(go, null).ToString()}");
            Debug.Log($"UnityEngine Object null: {(go == null).ToString()}");
            go = GameObject.Find("NullTest");
            Debug.Log($"go set");
            Debug.Log($"Reference Equals null: {ReferenceEquals(go, null).ToString()}");
            Debug.Log($"UnityEngine Object null: {(go == null).ToString()}");
            Destroy(go);
            // Destroy is not execute immediately, wait for it.
            yield return waitTime;
            Debug.Log("Destroy(go)");
            Debug.Log($"Reference Equals null: {ReferenceEquals(go, null).ToString()}");
            Debug.Log($"UnityEngine Object null: {(go == null).ToString()}");
            go = null;
            Debug.Log("go null");
            Debug.Log($"Reference Equals null: {ReferenceEquals(go, null).ToString()}");
            Debug.Log($"UnityEngine Object null: {(go == null).ToString()}");
        }
    }
}