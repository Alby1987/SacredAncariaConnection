using Ionic.Zlib;
using SacredAncariaConnectionClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SacredAncariaConnectionClient.Utilities
{
    internal static class Utils
    {
        internal static byte[] DecompressData(byte[] compressed)
        {
            var compressedData = new byte[compressed.Length - 4];
            Array.Copy(compressed, 4, compressedData, 0, compressedData.Length);
            return ZlibStream.UncompressBuffer(compressedData);
        }

        internal static (byte[] bytes, string base64) CompressData(byte[] originalHeader, byte[] uncompressedData)
        {
            var compressedToSend = ZlibStream.CompressBuffer(uncompressedData);

            var resultArray = new byte[4 + compressedToSend.Length];
            Array.Copy(originalHeader, resultArray, originalHeader.Length);
            Array.Copy(compressedToSend, 0, resultArray, 4, compressedToSend.Length);
            var base64 = Convert.ToBase64String(resultArray);
            return (resultArray, base64);
        }

        internal static Dictionary<string, string> ReadConfiguration(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }

            var toReturn = new Dictionary<string, string>();
            try
            {
                using (var configurationFile = new StreamReader(filename))
                {
                    while (true)
                    {
                        var line = configurationFile.ReadLine();
                        if (line == null)
                        {
                            break;
                        }
                        var elements = line.Split(new[] { " : " }, StringSplitOptions.None);
                        toReturn.Add(elements[0], elements[1]);
                    }
                }

                return toReturn;
            }
            catch (Exception)
            {
                return null;
            }

        }

        internal static void WriteConfiguration(string filename, Dictionary<string, string> values)
        {
            if (File.Exists(filename))
            {
                File.Copy(filename, $"{filename}.bak", true);
            }

            var data = ReadConfiguration(filename);

            if (data == null)
            {
                data = new Dictionary<string, string>();
            }

            foreach (var keyValue in values)
            {
                data[keyValue.Key] = keyValue.Value;
            }

            try
            {
                File.Delete(filename);

                using (var configurationFile = new StreamWriter(filename))
                {
                    foreach (var datum in data)
                    {
                        if (Enum.TryParse<ConfigurationEntries>(datum.Key, out _))
                        {
                            configurationFile.WriteLine($"{datum.Key} : {datum.Value}");
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        internal static string ConvertIP(byte[] ip)
        {
            return new IPAddress(ip).ToString();
        }

        internal static byte[] ConvertIP(string ip)
        {
            if (IPAddress.TryParse(ip, out var ipResult))
            {
                var result = ipResult.GetAddressBytes();
                if (result.Length != 4)
                {
                    return new byte[] { 0, 0, 0, 0 };
                }

                return result;
            }

            return new byte[] { 0, 0, 0, 0 };
        }
    }
}
