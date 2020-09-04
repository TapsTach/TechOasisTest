using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechOasisTest.WebApi.Services
{
    public static class Helper
    {
        public static async void Await(this Task task, Action<Exception> exceptionCallback)
        {
            try
            {
                await task;
            }
            catch(Exception ex)
            {
                exceptionCallback?.Invoke(ex);
            }
        }
    }
}
