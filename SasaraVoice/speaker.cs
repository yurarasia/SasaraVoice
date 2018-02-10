using CeVIO.Talk.RemoteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasaraVoice
{
    /// <summary>
    /// さとうささらの外部連携のラッパー
    /// </summary>
    public class Speaker : IDisposable
    {
        private Talker _talker;

        public Speaker()
        {
            ServiceControl.StartHost(false);
            _talker = new Talker
            {
                Cast = "さとうささら",
                Volume = 100,
                ToneScale = 0,
            };
        }

        public void Speak(string text)
        {
            _talker.Speak(text).Wait();
        }

        public PhonemeData[] GetPhonemeDatas(string text)
        {
            return _talker.GetPhonemes(text);
        }

        public void Dispose()
        {
            ServiceControl.CloseHost();
        }
    }
}
