using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Professional.Coding.Farm.Domain
{
    public abstract class Aggregate<TKey> : Aggregate where TKey : struct
    {
        public virtual TKey Id { get; protected set; }

        public virtual byte[] Version { get; protected set; }
    }

    public abstract class Aggregate : Entity
    {
        public Aggregate()
        { }
    }
}
