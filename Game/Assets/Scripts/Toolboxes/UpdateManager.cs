using System;
using UnityEngine;
namespace Toolboxes
{
    [CreateAssetMenu(fileName = "ManagerUpdate", menuName = "SO/ManagerUpdate", order = 0)]
    public class UpdateManager : ScriptableObject
    {
        private static event Action _onUpdate;
        private static event Action _onFixedUpdate;
        private static event Action _onLateUpdate;
        public static void AddUpdate(params Action[] action)
        {
            foreach (var item in action)
            {
                _onUpdate += item;
            }
        }
        public static void RemoveUpdate(params Action[] action)
        {
            foreach (var item in action)
            {
                _onUpdate -= item;
            }
        }
        public static void AddFixedUpdate(params Action[] action)
        {
            foreach (var item in action)
            {
                _onFixedUpdate += item;
            }
        }
        public static void RemoveFixedUpdate(params Action[] action)
        {
            foreach (var item in action)
            {
                _onFixedUpdate -= item;
            }
        }
        public static void AddLateUpdate(params Action[] action)
        {
            foreach (var item in action)
            {
                _onLateUpdate += item;
            }
        }
        public static void RemoveLateUpdate(params Action[] action)
        {
            foreach (var item in action)
            {
                _onLateUpdate -= item;
            }
        }
        private void OnDisable()
        {
            ClearEvents();
        }
        public static void ClearEvents()
        {
            _onUpdate = null;
            _onFixedUpdate = null;
            _onLateUpdate = null;
        }
        public void Update()
        {
            _onUpdate?.Invoke();
        }
        public void FixedUpdate()
        {
            _onFixedUpdate?.Invoke();
        }
        public void LateUpdate()
        {
            _onLateUpdate?.Invoke();
        }
    }
}