using System;
using System.Collections.Generic;
using System.Text;

namespace Clicker
{
    public interface IAudio
    {
        void PlayAudioFile(string fileName);
        void Stop(string fileName);

    }
}
