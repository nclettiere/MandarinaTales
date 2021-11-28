using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraManagement
{

    public class DynamicCamera : MonoBehaviour
    {
        [Header("(Required) Camera object and target")]
        [SerializeField]
        private Camera CameraObject;
        [SerializeField]
        private Transform target;

        [Header("(Optional) Camera options")]

        [SerializeField]
        private Vector2 cameraOffset = new Vector3(10f, 3.5f);

        [SerializeField]
        private bool allowBounds = true; 

        [SerializeField]
        private bool allowSmoothing = true; 

        [SerializeField]
        private float bounds = 3f;

        [Range(0, 10)]
        [SerializeField]
        private float smoothingAmount = 10f;

        [Range(0, 10)]
        [SerializeField]
        private float cameraMoveMultiplier = 2.5f;
        
        private Vector2 newCameraPosition;
        private Vector2 lastCameraPosition;
        private string lastTargetTag;
        private float currentPosZ;

        public bool FollowTarget = true;

        private Vector2 cameraMoveOffset = Vector3.zero;

        private void Start()
        {
            currentPosZ = transform.position.z;
        }

        private void FixedUpdate()
        {
            if (target == null || !FollowTarget)
                return;
            
            newCameraPosition = (Vector2) target.position + cameraOffset + cameraMoveOffset;

            if (target != null) {
                lastCameraPosition = target.position;
                lastTargetTag = target.tag;
            }

            if (allowBounds)
            {
                float deltaX = lastCameraPosition.x - transform.position.x;

                if (Mathf.Abs(deltaX) > bounds)
                {
                    // Derecha
                    if (deltaX > 0)
                    {
                        newCameraPosition.x =
                            lastCameraPosition.x - bounds + cameraOffset.x;
                    }
                    else
                    {
                        // Izquierda
                        newCameraPosition.x =
                            lastCameraPosition.x + bounds + cameraOffset.x;
                    }
                }
                else
                {
                    newCameraPosition.x =
                        lastCameraPosition.x - deltaX + cameraOffset.x;      
                }
            }

            if (allowSmoothing)
            {
                var smooth = Vector2
                    .Lerp(transform.position,
                        newCameraPosition,
                        Time.deltaTime * smoothingAmount);

                transform.position =
                    new Vector3(smooth.x, smooth.y, currentPosZ);
            }
            else
            {
                transform.position =
                    new Vector3(newCameraPosition.x, newCameraPosition.y, currentPosZ);
            }
        }

        public void ChangeTarget(Transform target)
        {
            this.target = target;
        }

        public void UpdateOffset(Vector2 offset)
        {
            cameraOffset = new Vector2(offset.x, offset.y);
        }


        public void UpdateOffsetX(float offsetX)
        {
           StartCoroutine(UpdateCameraOffsetX(offsetX));
        }

        public Vector2 GetOffsets()
        {
            return new Vector2(cameraOffset.x, cameraOffset.y);
        }


        public void UpdateOffsetY(float offsetY)
        {
            StartCoroutine(UpdateCameraOffsetY(offsetY));
        }

        public void UpdateSize(float size, float duration = 3f)
        {
            if(CameraObject != null)
                StartCoroutine(UpdateCameraSize(size, duration));
        }

        private IEnumerator UpdateCameraSize(float endValue, float duration)
        {
            float time = 0;
            float startValue = CameraObject.orthographicSize;

            while (time < duration)
            {
                CameraObject.orthographicSize =
                    Mathf.Lerp(startValue, endValue, time / duration);

                time += Time.deltaTime;
                yield return null;
            }
            CameraObject.orthographicSize = endValue;
        }

        private IEnumerator UpdateCameraOffsetX(float endValue, float duration = 0.3f)
        {
            float time = 0;
            float startValue = cameraOffset.x;

            while (time < duration)
            {
                cameraOffset.x =
                    Mathf.Lerp(startValue, endValue, time / duration);

                time += Time.deltaTime;
                yield return null;
            }
            cameraOffset.x = endValue;
        }

        private IEnumerator UpdateCameraOffsetY(float endValue, float duration = 0.3f)
        {
            float time = 0;
            float startValue = cameraOffset.y;

            while (time < duration)
            {
                cameraOffset.y =
                    Mathf.Lerp(startValue, endValue, time / duration);

                time += Time.deltaTime;
                yield return null;
            }
            cameraOffset.y = endValue;
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        public void UpdateOffsetJoystick(Vector2 value)
        {
            cameraMoveOffset = new Vector3(value.x, value.y) * cameraMoveMultiplier;
        }
    }
}
