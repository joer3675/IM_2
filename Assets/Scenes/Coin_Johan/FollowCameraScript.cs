using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace UnityEngine.XR.ARFoundation
{
    public class FollowCameraScript : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private GameObject _camera;

        [SerializeField]
        private GameObject spawnRandomCoins;

        private SpawnRandomCoins coinsLeft;

        [SerializeField]
        private Text _score;
        private int highscoore;
        void Start()
        {
            coinsLeft = spawnRandomCoins.GetComponent<SpawnRandomCoins>();
        }

        // Update is called once per frame
        void Update()
        {
            this.gameObject.transform.position = _camera.transform.position;



        }

        void OnTriggerEnter(Collider collision)
        {
            Debug.Log("Here");
            if (collision.gameObject.CompareTag("CoinTag"))
            {
                highscoore++;
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                Debug.Log("Hit!");
                _score.text = highscoore.ToString();
                coinsLeft.numberOfSpawnCoins++;
            }

        }

    }
}
