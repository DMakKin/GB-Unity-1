using UnityEngine;

namespace DM
{
    public class PortalController : BaseController
    {
        private PortalCameraLand _portalCameraLand;
        private PortalCameraCave _portalCameraCave;

        public PortalController()
        {
            _portalCameraLand = Object.FindObjectOfType<PortalCameraLand>();
            _portalCameraCave = Object.FindObjectOfType<PortalCameraCave>();
        }

        public override void OnUpdate()
        {
            Vector3 playerOffsetFromPortal = _portalCameraLand._playerCamera.position - _portalCameraLand._cavePortal.position;
            _portalCameraLand.transform.position = _portalCameraLand._landPortal.position + playerOffsetFromPortal;

            _portalCameraLand.transform.rotation = Quaternion.LookRotation(_portalCameraLand._playerCamera.forward, Vector3.up);

            Vector3 playerOffsetFromPortalCave = _portalCameraCave._playerCamera.position - _portalCameraCave._cavePortal.position;
            _portalCameraCave.transform.position = _portalCameraCave._landPortal.position + playerOffsetFromPortalCave;

            _portalCameraCave.transform.rotation = Quaternion.LookRotation(_portalCameraCave._playerCamera.forward, Vector3.up);
        }
    }
}
