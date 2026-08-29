using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal abstract class Component
    {
        public string Name { get; set; }
        public GameObject GameObect {  get; internal set; }

        public virtual void Start() { }

        public virtual void Update(float deltaTime) { }
    }
}
