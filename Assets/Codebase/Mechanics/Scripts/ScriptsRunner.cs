using System;
using System.Collections.Generic;
using VContainer.Unity;
using UnityEngine;

namespace Mechanics.Scripts
{
    public class ScriptsRunner : IStartable, IDisposable
    {
        private readonly IEnumerable<IGameScript> _scripts;

        public ScriptsRunner(IEnumerable<IGameScript> scripts)
        {
            _scripts = scripts;
        }

        void IStartable.Start()
        {
            foreach (var script in _scripts)
                script.Activate();
        }

        public void Dispose()
        {
            foreach (var script in _scripts)
                script.Deactivate();
        }
    }
}