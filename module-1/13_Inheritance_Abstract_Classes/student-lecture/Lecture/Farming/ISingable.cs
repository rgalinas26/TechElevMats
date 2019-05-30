using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Farming
{
    /// <summary>
    /// Any class that supoprts ISingable can be sung about.
    /// </summary>
    public interface ISingable
    {
        /// <summary>
        /// The name of the singable object
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Make a sound native to this class
        /// </summary>
        /// <returns>A sound, once</returns>
        string MakeSoundOnce();

        /// <summary>
        /// Make a sound native to this class
        /// </summary>
        /// <returns>A sound, repeated</returns>
        string MakeSoundTwice();
    }
}
