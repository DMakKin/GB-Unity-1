using UnityEngine;

namespace DM
{
    public class TeleporterController : BaseController
    {
        private TeleporterLand _teleporterLand;
        private TeleporterCave _teleporterCave;

        public TeleporterController()
        {
            _teleporterLand = Object.FindObjectOfType<TeleporterLand>();
            _teleporterCave = Object.FindObjectOfType<TeleporterCave>();
        }

        public override void OnUpdate()
        {
            if (_teleporterLand.playerIsOverlapping)
            {
                Vector3 portalToPlayer = _teleporterLand._player.position - _teleporterLand.transform.position;
                float dotProduct = Vector3.Dot(_teleporterLand.transform.up, portalToPlayer);

                if (dotProduct < 0f) //Переместить игрока если истина
                {
                    float rotationDiff = -Quaternion.Angle(_teleporterLand.transform.rotation, _teleporterLand._receiver.rotation);
                    rotationDiff += 180;
                    _teleporterLand._player.Rotate(Vector3.up, rotationDiff);

                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                    _teleporterLand._player.position = _teleporterLand._receiver.position + positionOffset;

                    _teleporterLand.playerIsOverlapping = false;
                }
            }

            if (_teleporterCave.playerIsOverlapping)
            {
                Vector3 portalToPlayer = _teleporterCave._player.position - _teleporterCave.transform.position;
                float dotProduct = Vector3.Dot(_teleporterCave.transform.up, portalToPlayer);

                if (dotProduct < 0f) //Переместить игрока если истина
                {
                    float rotationDiff = -Quaternion.Angle(_teleporterCave.transform.rotation, _teleporterCave._receiver.rotation);
                    rotationDiff += 180;
                    _teleporterCave._player.Rotate(Vector3.up, rotationDiff);

                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                    _teleporterCave._player.position = _teleporterCave._receiver.position + positionOffset;

                    _teleporterCave.playerIsOverlapping = false;
                }
            }
        }
    }
}
