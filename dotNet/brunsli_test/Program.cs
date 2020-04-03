// Copyright (c) Google LLC 2019
// Tiszai Istvan
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using System;
using System.Diagnostics;
using System.IO;
using brunslinetwrapper;

namespace brunsli_test
{
    class Program
    {      
        static void Main(string[] args)
        {
            bool _encoder = false;
            string _filename_in = "";
            string _filename_out = "";

            if (args.Length < 2) 
            {
                usageMessage();
                return;
            }
            if (args[0].Equals("-enc")) 
            {
                _encoder = true;
            }
            else
            if (args[0].Equals("-dec")) 
            {
                _encoder = false;
            }
            else
            {
                Console.WriteLine("Not founded -enc or -dec");
                usageMessage();
                return;
            }
            if (args[1] != "")
            {
                _filename_in = args[1];
                if (args.Length >= 3)
                {
                    if (args[2] != "")
                    {
                        _filename_out = args[2];
                    }
                    else
                    {
                        _filename_out = args[2];
                    }
                }
            }
            else
            {
                Console.WriteLine("Empty input file name");
                usageMessage();
                return;
            }          
            if (Path.GetExtension(_filename_in) == "")
            {
                if (_encoder)
                {
                    _filename_in += ".jpg";
                }
                else
                {
                    _filename_in += ".jpgxl";
                }
            }
            if (_filename_out == "")
            {
                string _dirname = Path.GetDirectoryName(_filename_in);
                if (_encoder)
                {
                    if (_dirname != "")
                    {
                        _filename_out = Path.GetDirectoryName(_filename_in) + "\\" + Path.GetFileNameWithoutExtension(_filename_in) + ".jpgxl";
                    }
                    else
                    {
                        _filename_out =  Path.GetFileNameWithoutExtension(_filename_in) + ".jpgxl";
                    }
                }
                else
                {
                    if (_dirname != "")
                    {
                        _filename_out = Path.GetDirectoryName(_filename_in) + "\\" + Path.GetFileNameWithoutExtension(_filename_in) + ".jpg";
                    }
                    else
                    {
                        _filename_out =  Path.GetFileNameWithoutExtension(_filename_in) + ".jpg";
                    }
                }
            }
            else
            {
                if (Path.GetExtension(_filename_out) == "")
                {                 
                    if (_encoder)
                    {
                        _filename_out += ".jpgxl";
                    }
                    else
                    {
                        _filename_out += ".jpg";
                    }
                }
            }
            Stopwatch _sw = new Stopwatch();
            _sw.Start();
            if (!_encoder) 
            {
                //string _filename_jpg = "foldesurak0.jpegxl";
                if (!File.Exists(_filename_in))
                {
                    Console.WriteLine($"Not founded {_filename_in}");
                    return;
                }
                byte[] _dataarray = File.ReadAllBytes(_filename_in);

                BrunsliWrapper _brWrapper = new BrunsliWrapper();
                {
                    byte[] _dataDecarray = _brWrapper.DecodeJpeg(_dataarray);
                    if (_dataDecarray != null)
                    {
                        File.WriteAllBytes(_filename_out, _dataDecarray);
                        Console.WriteLine($"Success decoding, save to '{_filename_out}'");
                    }
                    else
                    {
                        Console.WriteLine($"Decode bad: {_filename_in}");
                    }
                }
            }
            else
            {
               // string _filename_jpg = "foldesurak.jpeg";
                if (!File.Exists(_filename_in))
                {
                    Console.WriteLine($"Not founded {_filename_in}");
                    return;
                }
                byte[] _dataarray = File.ReadAllBytes(_filename_in);
                BrunsliWrapper _brWrapper = new BrunsliWrapper();
                {
                    byte[] _dataDecarray = _brWrapper.EncodeJpeg(_dataarray);
                    if (_dataDecarray != null)
                    {
                        File.WriteAllBytes(_filename_out, _dataDecarray);
                        Console.WriteLine($"Success encoding, save to '{_filename_out}'");
                    }
                    else
                    {
                        Console.WriteLine($"Encode bad: {_filename_in}");
                    }
                }
            }
            _sw.Stop();
            long _source_file_size = new FileInfo(_filename_in).Length;
            long _result_file_size = new FileInfo(_filename_out).Length;
            Console.WriteLine($"in file of size: {_source_file_size}, result file os size: {_result_file_size}");
            Console.WriteLine($"For Encoding/decoding have elapsed time: {_sw.Elapsed}");
            Console.WriteLine("press any key ....");
            Console.ReadKey();
        }
        static void usageMessage()
        {
            Console.WriteLine("Usage: brunsli_test -enc FILE[.jpg] [OUTPUT_FILE[.jpgxl]]" + Environment.CommandLine +
                   "brunsli_test -dec FILE.[jpgxl] [OUTPUT_FILE[.jpg]");
            Console.ReadKey();
        }
    }
}
