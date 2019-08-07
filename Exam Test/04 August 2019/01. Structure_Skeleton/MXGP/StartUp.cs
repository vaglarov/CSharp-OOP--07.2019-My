using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engien = new Engine();
            engien.Run();

        }
    }
}
