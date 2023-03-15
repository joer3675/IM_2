using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;


namespace UnityEngine.XR.ARFoundation.Samples
{
    public class FollowCameraScript : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private AudioSource soundClip;
        // [SerializeField]
        // private AudioClip aClip;

        [SerializeField]
        private GameObject _camera;

        [SerializeField]
        private GameObject spawnRandomCoins;

        private SpawnRandomCoins coinsLeft;

        [SerializeField]
        private TMP_Text _score;
        private int highscoore;
        [SerializeField]
        private int scoreGameOver;
        [SerializeField]
        private GameObject panelGameOver;




        void Start()
        {
            soundClip = GetComponent<AudioSource>();
            coinsLeft = spawnRandomCoins.GetComponent<SpawnRandomCoins>();
        }

        // Update is called once per frame
        void Update()
        {
            this.gameObject.transform.position = _camera.transform.position;



        }

        void OnTriggerEnter(Collider collision)
        {

            if (collision.gameObject.CompareTag("CoinTag"))
            {
                if (highscoore >= scoreGameOver)
                {
                    panelGameOver.gameObject.SetActive(true);
                    panelGameOver.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = highscoore.ToString();
                    return;
                }

                soundClip.Play();
                highscoore++;
                collision.gameObject.GetComponent<BoxCollider>().enabled = false;

                SpawnRandomCoins.spawnedObjects.Remove(collision.gameObject);
                collision.gameObject.GetComponent<CoinParticleEffect>().PlayEffect();
                //Destroy(collision.gameObject);
                _score.text = highscoore.ToString();
                SpawnRandomCoins.spawnedObjects.Remove(this.gameObject);


            }

        }

    }
}
