using System;
using NaughtyAttributes;
using UnityEngine;

namespace MixamoRagdoll
{
    public class RagdollController : MonoBehaviour
    {
        [SerializeField, HideInInspector] private Rigidbody[] _rigidbodies;
        [SerializeField] private float _mass;
        [SerializeField] private Rigidbody _main;

        public event Action EnabledKinematic;
        public event Action DisabledKinematic;
    
        public Rigidbody Main => _main;
        public Rigidbody[] Rigidbodies =>_rigidbodies;
        
        public void SetRigidbodies(Rigidbody[] rigidbodies, Rigidbody main)
        {
            _main = main;
            _rigidbodies = rigidbodies;
        }

        [Button()]
        public void RemoveMass()
        {
            foreach (Rigidbody rigidbody in _rigidbodies)
            {
                rigidbody.mass = 0.1f;
                rigidbody.useGravity = false;
            }
        }
    
        public void AddMass()
        {
            foreach (Rigidbody rigidbody in _rigidbodies)
            {
                rigidbody.mass = _mass;
                rigidbody.useGravity = true;
            }
        }
        
        public void EnableKinematic()
        {
            EnabledKinematic?.Invoke();
        
            foreach (Rigidbody rigidbody in _rigidbodies)
                rigidbody.isKinematic = true;
        }
        
        public void DisableKinematic()
        {
            DisabledKinematic?.Invoke();
        
            foreach (Rigidbody rigidbody in _rigidbodies)
                rigidbody.isKinematic = false;
        }
    }
}