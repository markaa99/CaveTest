using UnityEngine;

namespace HTW.CAVE.Samples.CAVETools
{
    public class CubeSpawnState : MonoBehaviour
    {
        public static bool Enabled = false;
        [SerializeField] private GameObject spawnposition1;

        private void OnEnable()
        {
            transform.position = spawnposition1.transform.position;
            //Enabled = true;
        }

        private void OnDisable()
        {
            Enabled = false;
        }
    }
}
