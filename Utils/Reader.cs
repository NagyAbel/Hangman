using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace NagyAbel.Utils
{
    static class Reader
    {
        public static string ReadString(string pre_text, params string[] valid_inputs)
        {
            Writer.Write(pre_text, Globals.fast);
            bool valid = false;
            string response = "";
            while (!valid)
            {
                try
                {
                    response = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        response = response.Trim().ToLower();
                        //All response are valid
                        if(valid_inputs.Length == 0)return response;

                        //Allow only specific responses
                        foreach (var option in valid_inputs)
                        {
                            if (response == option.ToLower())
                            {
                                return response;
                            }
                        }
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Writer.Write(pre_text, Globals.fast);
                    valid = false;
                }
            }
            return response;
        }

        public static int ReadInt(string pre_text, params int[] valid_inputs)
        {
            Writer.Write(pre_text, Globals.fast);
            bool valid = false;
            int response = -1;
            while (!valid)
            {
                try
                {
                    response = int.Parse(Console.ReadLine() ?? "");
                    foreach (var option in valid_inputs)
                    {
                        if (response == option)
                        {
                            return response;
                        }
                    }
                    throw new Exception();

                }
                catch (Exception)
                {
                    Writer.Write(pre_text, Globals.fast);
                    valid = false;
                }
            }
            return response;
        }

        public static char ReadChar(string pre_text){
            Writer.Write(pre_text, Globals.fast);
            bool valid = false;
            string response = "";
            while (!valid)
            {
                try
                {
                    response = Console.ReadLine() ?? "";
                    if (string.IsNullOrWhiteSpace(response))throw new Exception();
                    else
                    {
                        response = response.Trim().ToLower();
                        if (response.Length > 1 || char.IsDigit(response[0])) throw new Exception();
                        return response[0];
                    }
                }
                catch (Exception)
                {
                    Writer.Write(pre_text, Globals.fast);
                    valid = false;
                }
            }
            return response[0];
        }



    }
}