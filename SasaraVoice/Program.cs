using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SasaraVoice
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var recognizer = new Recognizer())
            using (var speaker = new Speaker())
            {
                recognizer.Recognized += (r) =>
                {
                    var phoneme = string.Join(",", speaker.GetPhonemeDatas(r.Text).Select(x => x.Phoneme));
                    Console.WriteLine($"{r.Text}\t{phoneme}\t{r.Confidence}");
                    speaker.Speak(r.Text);
                };

                while (true)
                {
                    var text = Console.ReadLine();
                    if (text == "quit")
                        break;
                }
            }
        }
    }
}
